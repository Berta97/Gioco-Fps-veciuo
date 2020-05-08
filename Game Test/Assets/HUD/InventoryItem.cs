using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.Inventory
{
    public interface IInventoryItem
    {
        string Name { get; }
        Sprite Image { get; }

        int Slot { get; }

        void OnPickup();

        void OnDrop();

        void SetCurrentSlot(int position);

    }

    public class InventoryEventArgs : EventArgs
    {
        public IInventoryItem savedItem;
        public InventoryEventArgs(IInventoryItem item)
        {
            savedItem = item;
        }
    }
}