using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Lang;
using Player.Inventory;

public class ExtractMaterial : Photon.MonoBehaviour
{

    [SerializeField]
    public Camera mainCamera;

    [SerializeField]
    public LayerMask itemLayer;

    [SerializeField]
    private float pickupTime = 2f;

    [SerializeField]
    public Transform messagePanel;

    [SerializeField]
    public Image progressBar;

    [SerializeField]
    public TextMeshProUGUI itemNameText;

    [SerializeField]
    public Inventory inventory;

    [SerializeField]
    public LanguageManager languageManager;

    private string itemBeingPickup;
    private float currentTimerElapsed;
    private IInventoryItem newItem = null;

    // Update is called once per frame
    void Update()
    {
        SelectedItemToPickupFromRay();

        if (HasItemTargetted())
        {
            messagePanel.gameObject.SetActive(true);
            
            if (Input.GetKey(KeyCode.E))
            {
                IncrementPickupProgress();
            }
            else
            {
                currentTimerElapsed = 0f;
            }

            UpdatePickupProgressImage();

        }
        else
        {
            messagePanel.gameObject.SetActive(false);
            currentTimerElapsed = 0f;
        }
    }


    private void IncrementPickupProgress()
    {
        currentTimerElapsed += Time.deltaTime;
        if(currentTimerElapsed >= pickupTime)
        {
            MoveItemToInventory();
            currentTimerElapsed = 0f;
        }
    }

    private void UpdatePickupProgressImage()
    {
        float ptc = currentTimerElapsed / pickupTime;
        progressBar.fillAmount = ptc;
    }

    private bool HasItemTargetted()
    {
        return itemBeingPickup != null;
    }

    private void SelectedItemToPickupFromRay()
    {
        Ray ray = mainCamera.ViewportPointToRay(Vector3.one / 2f);
        Debug.DrawRay(ray.origin, ray.direction * 2f, Color.red);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, 2f, itemLayer))
        {
            var hitItem = hitInfo.collider.GetComponent<Renderer>().material.name.Split(' ')[0];

            if (hitItem == null)
            {
                itemBeingPickup = null;
            }
            else if (hitItem != null && hitItem != itemBeingPickup)
            {
                itemBeingPickup = hitItem;
                itemNameText.text = languageManager.lang.takeMessage + itemBeingPickup;
            }
        }
        else
        {
            itemBeingPickup = null;
        }
    }

    private void MoveItemToInventory()
    {
        if (itemBeingPickup.CompareTo("Pietra") == 0)
        {
            newItem = gameObject.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<StoneWeapon>();
        }

        if (itemBeingPickup.CompareTo("Legno") == 0)
        {
            newItem = gameObject.transform.GetChild(0).GetChild(0).GetChild(1).GetComponent<StickWeapon>();
        }

        inventory.AddItem(newItem);
    }

}
