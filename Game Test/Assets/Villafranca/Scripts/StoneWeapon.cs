using UnityEngine;
using Player.Inventory;
public class StoneWeapon : Item
{
    
    public override string Name
    {
        get
        {
            return languageManager.lang.stone;
        }
    }

    public override Sprite Image 
    {
        get
        {
            return _image;
        }
    }

}
