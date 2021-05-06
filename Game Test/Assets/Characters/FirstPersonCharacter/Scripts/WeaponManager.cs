﻿using UnityEngine;
using UnityEngine.UI;
using Player.Inventory;

namespace Player.Weapon
{
    public enum Weapon { empty, stone, stick, flint, spear, slingshot };

    public interface IShoot
    {
        void Shoot();
    }

    public class WeaponManager : Photon.MonoBehaviour
    {
        [SerializeField]
        public GameObject weaponHolder;

        [SerializeField]
        public WeaponPanel weaponPanel;

        private Weapon currentWeapon;

        private int currentAmmo = 0;

        private Text ammoText;

        void Start()
        {
            weaponPanel.itemAdded += WeaponPanel_script_ItemAdded;
            weaponPanel.itemRemoved += WeaponPanel_script_ItemRemoved;
            ammoText = GameObject.FindGameObjectsWithTag("AmmoText")[0].GetComponent<Text>();
        }

        void Update()
        {
            if (photonView.isMine && Input.GetMouseButtonDown(0) && currentWeapon != Weapon.empty)
            {
                IShoot weapon;
                GameObject item;

                currentAmmo--;

                switch (currentWeapon)
                {
                    case (Weapon.stone):
                        item = weaponHolder.transform.GetChild(0).gameObject;
                        weapon = item.GetComponent<StoneWeapon>();
                        weapon.Shoot();
                        if (currentAmmo == 0)
                            weaponPanel.RemoveItem(item.GetComponent<IInventoryItem>());
                        break;
                    case (Weapon.stick):
                        item = weaponHolder.transform.GetChild(1).gameObject;
                        weapon = item.GetComponent<StickWeapon>();
                        weapon.Shoot();
                        if (currentAmmo == 0)
                            weaponPanel.RemoveItem(item.GetComponent<IInventoryItem>());
                        break;
                    case (Weapon.flint):
                        item = weaponHolder.transform.GetChild(2).gameObject;
                        weapon = item.GetComponent<FlintWeapon>();
                        weapon.Shoot();
                        if (currentAmmo == 0)
                            weaponPanel.RemoveItem(item.GetComponent<IInventoryItem>());
                        break;
                    case (Weapon.spear):
                        break;
                    default: break;
                }
            }

            if (photonView.isMine)
                ammoText.text = currentAmmo.ToString();
        }

        private void WeaponPanel_script_ItemAdded(object sender, InventoryEventArgs e)
        {
            if (photonView.isMine)
            {
                Transform hud = transform.Find("HUD");
                Transform weaponPanel = hud.Find("WeaponPanel");

                Image image = weaponPanel.GetChild(0).GetChild(0).GetChild(0).GetComponent<Image>();
                image.enabled = true;
                image.sprite = e.savedItem.Image;
                DisableWeapon();
                EnableWeapon(e.savedItem.ID);
            }
        }

        private void WeaponPanel_script_ItemRemoved(object sender, InventoryEventArgs e)
        {
            if (photonView.isMine)
            {
                Transform hud = transform.Find("HUD");
                Transform weaponPanel = hud.Find("WeaponPanel");

                Image image = weaponPanel.GetChild(0).GetChild(0).GetChild(0).GetComponent<Image>();
                image.enabled = false;
                DisableWeapon();

            }
        }


        public void EnableWeapon(Weapon name)
        {
            currentWeapon = name;

            GameObject weap;

            switch (name)
            {
                case (Weapon.stone):
                    photonView.RPC("EnablePlayerWeapon", PhotonTargets.AllBuffered, 0);
                    weap = weaponHolder.transform.GetChild(0).gameObject;
                    currentAmmo = weap.GetComponent<StoneWeapon>().munitions;
                    break;
                case (Weapon.stick):
                    photonView.RPC("EnablePlayerWeapon", PhotonTargets.AllBuffered, 1);
                    weap = weaponHolder.transform.GetChild(1).gameObject;
                    currentAmmo = weap.GetComponent<StickWeapon>().munitions;
                    break;
                case (Weapon.flint):
                    photonView.RPC("EnablePlayerWeapon", PhotonTargets.AllBuffered, 2);
                    weap = weaponHolder.transform.GetChild(2).gameObject;
                    currentAmmo = weap.GetComponent<FlintWeapon>().munitions;
                    break;
                case (Weapon.spear):
                    break;
                default: break;
            }
        }

        public void DisableWeapon()
        {
            currentAmmo = 0;

            switch (currentWeapon)
            {
                case (Weapon.stone):
                    photonView.RPC("DisablePlayerWeapon", PhotonTargets.AllBuffered, 0);
                    currentWeapon = Weapon.empty;
                    break;
                case (Weapon.stick):
                    photonView.RPC("DisablePlayerWeapon", PhotonTargets.AllBuffered, 1);
                    currentWeapon = Weapon.empty;
                    break;
                case (Weapon.flint):
                    photonView.RPC("DisablePlayerWeapon", PhotonTargets.AllBuffered, 2);
                    currentWeapon = Weapon.empty;
                    break;
                case (Weapon.spear):
                    currentWeapon = Weapon.empty;
                    break;
                default: break;
            }
        }

        [PunRPC]
        void EnablePlayerWeapon(int childToActive)
        {
            weaponHolder.transform.GetChild(childToActive).gameObject.SetActive(true);
        }

        [PunRPC]
        void DisablePlayerWeapon(int childToActive)
        {
            weaponHolder.transform.GetChild(childToActive).gameObject.SetActive(false);
        }

    }
}