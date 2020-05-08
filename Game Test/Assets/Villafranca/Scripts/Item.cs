using UnityEngine;
using Lang;
using Player.Inventory;

public class Item : MonoBehaviour, IInventoryItem
{
    [SerializeField]
    public LanguageManager languageManager;

    [SerializeField]
    public Sprite _image = null;

    [SerializeField]
    public Vector3 pickPosition;

    [SerializeField]
    public Vector3 pickRotation;

    private int slot = 0;

    public virtual string Name { get { return "_base_item_"; } }

    public virtual Sprite Image { get { return _image; } }

    public int Slot { get { return slot; } }

    public virtual void OnDrop()
    {
        
    }

    public virtual void OnPickup()
    {
        gameObject.SetActive(true);

    }

    public void SetCurrentSlot(int position)
    {
        slot = position;
    }
}
