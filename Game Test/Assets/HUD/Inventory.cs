using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;


namespace Player.Inventory
{
    public class Inventory : MonoBehaviour
    {

        private const int SLOTS = 2;

        private IInventoryItem[] mItem = new IInventoryItem[SLOTS];

        public event EventHandler<InventoryEventArgs> itemAdded;

        public event EventHandler<InventoryEventArgs> itemRemoved;

        public void AddItem(IInventoryItem item)
        {
            int slot = FindSlot();

            if (slot < SLOTS)
            {
                item.SetCurrentSlot(slot);
                mItem[slot] = item;
                itemAdded?.Invoke(this, new InventoryEventArgs(item));
            }
        }

        public IInventoryItem GetItem(int position)
        {
            return position < SLOTS ? mItem[position] : null;
        }

        public void ClearSlot(int position)
        {
            if(position < SLOTS)
            {
                IInventoryItem tmp = GetItem(position);
                mItem[position] = null;
                itemRemoved?.Invoke(this, new InventoryEventArgs(tmp));
            }
        }

        private int FindSlot()
        {
            for(int i = 0; i < SLOTS; i++)
            {
                if (mItem[i] == null)
                    return i;
            }
            return SLOTS;
        }
    }
}

