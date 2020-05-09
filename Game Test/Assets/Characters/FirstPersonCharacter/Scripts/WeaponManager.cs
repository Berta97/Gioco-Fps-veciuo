using UnityEngine;
using UnityEngine.UI;
using Player.Inventory;

namespace Player.Weapon
{
    public enum Weapon { empty, stone };

    public class WeaponManager : Photon.MonoBehaviour
    {
        [SerializeField]
        public GameObject weaponHolder;

        [SerializeField]
        public WeaponPanel weaponPanel;

        private Weapon currentWeapon;

        void Start()
        {
            weaponPanel.itemAdded += WeaponPanel_script_ItemAdded;
            weaponPanel.itemRemoved += WeaponPanel_script_ItemRemoved;
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
            switch (name)
            {
                case (Weapon.stone):
                    photonView.RPC("EnablePlayerWeapon", PhotonTargets.AllBuffered, 0);
                    break;
                default: break;
            }
        }

        public void DisableWeapon()
        {
            switch (currentWeapon)
            {
                case (Weapon.stone):
                    photonView.RPC("DisablePlayerWeapon", PhotonTargets.AllBuffered, 0);
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