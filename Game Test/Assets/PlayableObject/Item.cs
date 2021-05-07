using UnityEngine;
using Player.Inventory;
using Player.Weapon;

public class Item : Photon.MonoBehaviour, IInventoryItem
{

    [SerializeField]
    public Sprite _image = null;

    [SerializeField]
    public int munitions = 1;

    [SerializeField]
    public int damage = 10;

    protected AudioSource waponSound;
    private int slot = 0;

    public virtual Weapon ID { get { return Weapon.empty; } }

    public virtual Sprite Image { get { return _image; } }

    public int Slot { get { return slot; } }

    public virtual void OnDrop()
    {
        //TODO
    }

    public virtual void OnPickup()
    {
        //
    }

    public void SetCurrentSlot(int position)
    {
        slot = position;
    }

    
}
