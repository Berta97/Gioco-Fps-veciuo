using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets.Characters.FirstPerson
{
    public interface IInventoryItem
    {
        string Name { get; }
        Sprite Image { get; }

        void onPickup();

    }

    public class InteractableItem : MonoBehaviour
    {
        public string interactText = "";

        public virtual void onInteract()
        {

        }
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