using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
public class Stone : InteractableItem, IInventoryItem
{
    public Sprite _image = null;
    public string Name
    {
        get
        {
            return "Stone";
        }
    }

    public Sprite Image 
    {
        get
        {
            return _image;
        }
    }

    public void onPickup()
    {

    }

    public override void onInteract()
    {
        interactText = "Premi E per indagare";

    }
}
