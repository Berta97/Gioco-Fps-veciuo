using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player.Inventory;

public class SwitchToActive : MonoBehaviour
{
    [SerializeField]
    public Inventory inventory;

    [SerializeField]
    public WeaponPanel weaponPanel;

    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            IInventoryItem weapon = inventory.GetItem(0);
            if (weapon != null)
            {
                weaponPanel.ClearSlot();
                weaponPanel.AddItem(weapon);
                inventory.ClearSlot(0);

            }

                
        }
        else if (Input.GetKey(KeyCode.Alpha2))
        {
            IInventoryItem weapon = inventory.GetItem(1);
            if (weapon != null)
            {
                weaponPanel.ClearSlot();
                inventory.ClearSlot(1);
                weaponPanel.AddItem(weapon);
            }
                
        }
        else if (Input.GetKey(KeyCode.C))
        {

        }
    }
}
