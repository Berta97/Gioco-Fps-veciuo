using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player.Inventory;
using Player.Weapon;

public class SwitchToActive : Photon.MonoBehaviour
{
    [SerializeField]
    public Inventory inventory;

    [SerializeField]
    public WeaponPanel weaponPanel;

    void Update()
    {
        if (photonView.isMine && Input.GetKey(KeyCode.Alpha1))
        {
            IInventoryItem weapon = inventory.GetItem(0);
            if (weapon != null)
            {
                weaponPanel.AddItem(weapon);
                inventory.ClearSlot(0);

            }

                
        }
        else if (photonView.isMine && Input.GetKey(KeyCode.Alpha2))
        {
            IInventoryItem weapon = inventory.GetItem(1);
            if (weapon != null)
            {
                inventory.ClearSlot(1);
                weaponPanel.AddItem(weapon);
            }
                
        }
        else if (photonView.isMine && Input.GetKey(KeyCode.C))
        {
            if (inventory.isFull())
            {
                if(inventory.GetItem(0).ID == Weapon.stone && inventory.GetItem(1).ID == Weapon.stone)
                {
                    inventory.ClearSlot(0);
                    inventory.ClearSlot(1);
                    inventory.AddItem(gameObject.transform.GetChild(0).GetChild(0).GetChild(2).GetComponent<FlintWeapon>());
                }

                if (inventory.GetItem(0).ID == Weapon.stone && inventory.GetItem(1).ID == Weapon.stick)
                {
                    inventory.ClearSlot(0);
                    inventory.ClearSlot(1);
                    inventory.AddItem(gameObject.transform.GetChild(0).GetChild(0).GetChild(3).GetComponent<SlingshotWeapon>());
                }

                if (inventory.GetItem(0).ID == Weapon.stick && inventory.GetItem(1).ID == Weapon.stone)
                {
                    inventory.ClearSlot(0);
                    inventory.ClearSlot(1);
                    inventory.AddItem(gameObject.transform.GetChild(0).GetChild(0).GetChild(4).GetComponent<SpearWeapon>());
                }

                if (inventory.GetItem(0).ID == Weapon.stick && inventory.GetItem(1).ID == Weapon.stick)
                {
                    inventory.ClearSlot(0);
                    inventory.ClearSlot(1);
                    inventory.AddItem(gameObject.transform.GetChild(0).GetChild(0).GetChild(5).GetComponent<BoomerangWeapon>());
                }
            }
        }
    }
}
