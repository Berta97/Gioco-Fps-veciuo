using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace UnityStandardAssets.Characters.FirstPerson
{
    public class Inventory : MonoBehaviour
    {

        private const int SLOTS = 6;

        private List<IInventoryItem> mItem = new List<IInventoryItem>();

        public event EventHandler<InventoryEventArgs> itemAdded;

        public void addItem(IInventoryItem item)
        {
            if (mItem.Count < SLOTS)
            {
                Collider collider = (item as MonoBehaviour).GetComponent<Collider>();
                if (collider.enabled)
                {
                    collider.enabled = false;
                    mItem.Add(item);
                    item.onPickup();

                    if (itemAdded != null)
                    {
                        itemAdded(this, new InventoryEventArgs(item));
                    }
                }
            }
        }
    }
}

