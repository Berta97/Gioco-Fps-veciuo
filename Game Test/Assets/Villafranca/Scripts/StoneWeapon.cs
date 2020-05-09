using UnityEngine;
using Player.Weapon;
public class StoneWeapon : Item
{
    
    public override Weapon ID
    {
        get
        {
            return Weapon.stone;
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
