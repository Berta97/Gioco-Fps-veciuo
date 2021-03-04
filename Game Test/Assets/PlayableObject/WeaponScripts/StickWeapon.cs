using Player.Weapon;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickWeapon : Item, IShoot
{
    public void Shoot()
    {
        Debug.Log("TI ARRIVA UNA MAZZOLATA!!!");
    }

    public override Weapon ID
    {
        get
        {
            return Weapon.stick;
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
