﻿using UnityEngine;
using UnityEngine.UI;
using Player.Inventory;

namespace Player.Weapon
{
    public enum Weapon { empty, stone, stick, flint, spear, slingshot, boomerang, brick, wall, metal, glass, light, fire };

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
                        if (currentAmmo <= 0)
                            weaponPanel.RemoveItem(item.GetComponent<IInventoryItem>());
                        break;
                    case (Weapon.stick):
                        item = weaponHolder.transform.GetChild(1).gameObject;
                        weapon = item.GetComponent<StickWeapon>();
                        weapon.Shoot();
                        if (currentAmmo <= 0)
                            weaponPanel.RemoveItem(item.GetComponent<IInventoryItem>());
                        break;
                    case (Weapon.flint):
                        item = weaponHolder.transform.GetChild(2).gameObject;
                        weapon = item.GetComponent<FlintWeapon>();
                        weapon.Shoot();
                        if (currentAmmo <= 0)
                            weaponPanel.RemoveItem(item.GetComponent<IInventoryItem>());
                        break;
                    case (Weapon.slingshot):
                        item = weaponHolder.transform.GetChild(3).gameObject;
                        weapon = item.GetComponent<SlingshotWeapon>();
                        weapon.Shoot();
                        if (currentAmmo <= 0)
                            weaponPanel.RemoveItem(item.GetComponent<IInventoryItem>());
                        break;
                    case (Weapon.spear):
                        item = weaponHolder.transform.GetChild(4).gameObject;
                        weapon = item.GetComponent<SpearWeapon>();
                        weapon.Shoot();
                        if (currentAmmo <= 0)
                            weaponPanel.RemoveItem(item.GetComponent<IInventoryItem>());
                        break;
                    case (Weapon.boomerang):
                        item = weaponHolder.transform.GetChild(5).gameObject;
                        weapon = item.GetComponent<BoomerangWeapon>();
                        weapon.Shoot();
                        if (currentAmmo <= 0)
                            weaponPanel.RemoveItem(item.GetComponent<IInventoryItem>());
                        break;
                    case (Weapon.brick):
                        item = weaponHolder.transform.GetChild(6).gameObject;
                        weapon = item.GetComponent<BrickWeapon>();
                        weapon.Shoot();
                        if (currentAmmo <= 0)
                            weaponPanel.RemoveItem(item.GetComponent<IInventoryItem>());
                        break;
                    case (Weapon.wall):
                        item = weaponHolder.transform.GetChild(7).gameObject;
                        weapon = item.GetComponent<WallWeapon>();
                        weapon.Shoot();
                        if (currentAmmo <= 0)
                            weaponPanel.RemoveItem(item.GetComponent<IInventoryItem>());
                        break;
                    case (Weapon.metal):
                        item = weaponHolder.transform.GetChild(8).gameObject;
                        weapon = item.GetComponent<MetalWeapon>();
                        weapon.Shoot();
                        if (currentAmmo <= 0)
                            weaponPanel.RemoveItem(item.GetComponent<IInventoryItem>());
                        break;
                    case (Weapon.glass):
                        item = weaponHolder.transform.GetChild(9).gameObject;
                        weapon = item.GetComponent<GlassWeapon>();
                        weapon.Shoot();
                        if (currentAmmo <= 0)
                            weaponPanel.RemoveItem(item.GetComponent<IInventoryItem>());
                        break;
                    case (Weapon.light):
                        item = weaponHolder.transform.GetChild(10).gameObject;
                        weapon = item.GetComponent<LightWeapon>();
                        weapon.Shoot();
                        if (currentAmmo <= 0)
                            weaponPanel.RemoveItem(item.GetComponent<IInventoryItem>());
                        break;
                    case (Weapon.fire):
                        item = weaponHolder.transform.GetChild(11).gameObject;
                        weapon = item.GetComponent<FireWeapon>();
                        weapon.Shoot();
                        if (currentAmmo <= 0)
                            weaponPanel.RemoveItem(item.GetComponent<IInventoryItem>());
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
                case (Weapon.slingshot):
                    photonView.RPC("EnablePlayerWeapon", PhotonTargets.AllBuffered, 3);
                    weap = weaponHolder.transform.GetChild(3).gameObject;
                    currentAmmo = weap.GetComponent<SlingshotWeapon>().munitions;
                    break;
                case (Weapon.spear):
                    photonView.RPC("EnablePlayerWeapon", PhotonTargets.AllBuffered, 4);
                    weap = weaponHolder.transform.GetChild(4).gameObject;
                    currentAmmo = weap.GetComponent<SpearWeapon>().munitions;
                    break;
                case (Weapon.boomerang):
                    photonView.RPC("EnablePlayerWeapon", PhotonTargets.AllBuffered, 5);
                    weap = weaponHolder.transform.GetChild(5).gameObject;
                    currentAmmo = weap.GetComponent<BoomerangWeapon>().munitions;
                    break;
                case (Weapon.brick):
                    photonView.RPC("EnablePlayerWeapon", PhotonTargets.AllBuffered, 6);
                    weap = weaponHolder.transform.GetChild(6).gameObject;
                    currentAmmo = weap.GetComponent<BrickWeapon>().munitions;
                    break;
                case (Weapon.wall):
                    photonView.RPC("EnablePlayerWeapon", PhotonTargets.AllBuffered, 7);
                    weap = weaponHolder.transform.GetChild(7).gameObject;
                    currentAmmo = weap.GetComponent<WallWeapon>().munitions;
                    break;
                case (Weapon.metal):
                    photonView.RPC("EnablePlayerWeapon", PhotonTargets.AllBuffered, 8);
                    weap = weaponHolder.transform.GetChild(8).gameObject;
                    currentAmmo = weap.GetComponent<MetalWeapon>().munitions;
                    break;
                case (Weapon.glass):
                    photonView.RPC("EnablePlayerWeapon", PhotonTargets.AllBuffered, 9);
                    weap = weaponHolder.transform.GetChild(9).gameObject;
                    currentAmmo = weap.GetComponent<GlassWeapon>().munitions;
                    break;
                case (Weapon.light):
                    photonView.RPC("EnablePlayerWeapon", PhotonTargets.AllBuffered, 10);
                    weap = weaponHolder.transform.GetChild(10).gameObject;
                    currentAmmo = weap.GetComponent<LightWeapon>().munitions;
                    break;
                case (Weapon.fire):
                    photonView.RPC("EnablePlayerWeapon", PhotonTargets.AllBuffered, 11);
                    weap = weaponHolder.transform.GetChild(11).gameObject;
                    currentAmmo = weap.GetComponent<FireWeapon>().munitions;
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
                case (Weapon.slingshot):
                    photonView.RPC("DisablePlayerWeapon", PhotonTargets.AllBuffered, 3);
                    currentWeapon = Weapon.empty;
                    break;
                case (Weapon.spear):
                    photonView.RPC("DisablePlayerWeapon", PhotonTargets.AllBuffered, 4);
                    currentWeapon = Weapon.empty;
                    break;
                case (Weapon.boomerang):
                    photonView.RPC("DisablePlayerWeapon", PhotonTargets.AllBuffered, 5);
                    currentWeapon = Weapon.empty;
                    break;
                case (Weapon.brick):
                    photonView.RPC("DisablePlayerWeapon", PhotonTargets.AllBuffered, 6);
                    currentWeapon = Weapon.empty;
                    break;
                case (Weapon.wall):
                    photonView.RPC("DisablePlayerWeapon", PhotonTargets.AllBuffered, 7);
                    currentWeapon = Weapon.empty;
                    break;
                case (Weapon.metal):
                    photonView.RPC("DisablePlayerWeapon", PhotonTargets.AllBuffered, 8);
                    currentWeapon = Weapon.empty;
                    break;
                case (Weapon.glass):
                    photonView.RPC("DisablePlayerWeapon", PhotonTargets.AllBuffered, 9);
                    currentWeapon = Weapon.empty;
                    break;
                case (Weapon.light):
                    photonView.RPC("DisablePlayerWeapon", PhotonTargets.AllBuffered, 10);
                    currentWeapon = Weapon.empty;
                    break;
                case (Weapon.fire):
                    photonView.RPC("DisablePlayerWeapon", PhotonTargets.AllBuffered, 11);
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