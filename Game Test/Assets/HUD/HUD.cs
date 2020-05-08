using UnityEngine;
using UnityEngine.UI;
using Player.Inventory;

public class HUD : MonoBehaviour
{
    [SerializeField]
    public Inventory inventory;

    [SerializeField]
    public WeaponPanel weaponPanel;

    [SerializeField]
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        inventory.itemAdded += Inventory_script_ItemAdded;
        inventory.itemRemoved += Inventory_script_ItemRemoved;
        weaponPanel.itemAdded += WeaponPanel_script_ItemAdded;
        weaponPanel.itemRemoved += WeaponPanel_script_ItemRemoved;
    }

    private void Inventory_script_ItemAdded(object sender, InventoryEventArgs e)
    {
        Transform inventoryPanel = transform.Find("InventoryPanel");
        Image image = inventoryPanel.GetChild(e.savedItem.Slot).GetChild(0).GetChild(0).GetComponent<Image>();
        image.enabled = true;
        image.sprite = e.savedItem.Image;

    }


    private void WeaponPanel_script_ItemAdded(object sender, InventoryEventArgs e)
    {
        Transform weaponPanel = transform.Find("WeaponPanel");

        Image image = weaponPanel.GetChild(0).GetChild(0).GetChild(0).GetComponent<Image>();
        image.enabled = true;
        image.sprite = e.savedItem.Image;

        IInventoryItem weapon = e.savedItem;
        GameObject goWeapon = (weapon as MonoBehaviour).gameObject;
        goWeapon.SetActive(true);

        goWeapon.transform.parent = player.transform;
        goWeapon.transform.localPosition = (weapon as Item).pickPosition;
        goWeapon.transform.localEulerAngles = (weapon as Item).pickRotation;

    }

    private void Inventory_script_ItemRemoved(object sender, InventoryEventArgs e)
    {
        Transform inventoryPanel = transform.Find("InventoryPanel");
        Image image = inventoryPanel.GetChild(e.savedItem.Slot).GetChild(0).GetChild(0).GetComponent<Image>();
        image.enabled = false;

    }

    private void WeaponPanel_script_ItemRemoved(object sender, InventoryEventArgs e)
    {
        Transform weaponPanel = transform.Find("WeaponPanel");

        Image image = weaponPanel.GetChild(0).GetChild(0).GetChild(0).GetComponent<Image>();
        image.enabled = false;

    }

}