using System;
using System.Collections.Generic;
using UnityEngine;
using Player.Inventory;

public class WeaponPanel : Photon.MonoBehaviour
{
    private IInventoryItem weaponUsed = null;

    public event EventHandler<InventoryEventArgs> itemAdded;

    public event EventHandler<InventoryEventArgs> itemRemoved;

    public void AddItem(IInventoryItem item)
    {
        weaponUsed = item;
        item.OnPickup();
        itemAdded?.Invoke(this, new InventoryEventArgs(item));

    }

    public void RemoveItem(IInventoryItem item)
    {
        weaponUsed = null;
        item.OnDrop();
        itemRemoved?.Invoke(this, new InventoryEventArgs(item));
    }


}


