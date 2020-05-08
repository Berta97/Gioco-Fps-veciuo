using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UnityStandardAssets.Characters.FirstPerson
{
    public class HUD : MonoBehaviour
    {

        public Inventory inventory;

        // Start is called before the first frame update
        void Start()
        {
            inventory.itemAdded += inventory_script_ItemAdded;
        }

        private void inventory_script_ItemAdded(object sender, InventoryEventArgs e)
        {
            Transform inventoryPanel = transform.Find("InventoryPanel");
            foreach(Transform slot in inventoryPanel)
            {
                Image image = slot.GetChild(0).GetChild(0).GetComponent<Image>();

                if (!image.enabled)
                {
                    image.enabled = true;
                    image.sprite = e.savedItem.Image;
                    break;
                }
            }

        }

    }
}