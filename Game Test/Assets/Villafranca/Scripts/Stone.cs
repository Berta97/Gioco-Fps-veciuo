using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
public class Stone : MonoBehaviour, IInventoryItem
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
}
