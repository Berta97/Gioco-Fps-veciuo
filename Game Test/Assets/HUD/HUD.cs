using UnityEngine;
using UnityEngine.UI;
using Player.Inventory;
using Player.Weapon;

public class HUD : Photon.MonoBehaviour
{
    [SerializeField]
    public Inventory inventory;

    // Start is called before the first frame update
    void Start()
    {
        inventory.itemAdded += Inventory_script_ItemAdded;
        inventory.itemRemoved += Inventory_script_ItemRemoved;
        
    }

    private void Inventory_script_ItemAdded(object sender, InventoryEventArgs e)
    {
        Transform inventoryPanel = transform.Find("InventoryPanel");
        Image image = inventoryPanel.GetChild(e.savedItem.Slot).GetChild(0).GetChild(0).GetComponent<Image>();
        image.enabled = true;
        image.sprite = e.savedItem.Image;

    }


    

    private void Inventory_script_ItemRemoved(object sender, InventoryEventArgs e)
    {
        Transform inventoryPanel = transform.Find("InventoryPanel");
        Image image = inventoryPanel.GetChild(e.savedItem.Slot).GetChild(0).GetChild(0).GetComponent<Image>();
        image.enabled = false;

    }

    
    
}