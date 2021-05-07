using Player.Weapon;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlintWeapon : Item, IShoot
{

    public void Start()
    {
        waponSound = GetComponent<AudioSource>();
    }
    public void Shoot()
    {
        Debug.Log("TAGLIO TUTTO!!");
        waponSound.Play();
    }

    public override Weapon ID
    {
        get
        {
            return Weapon.flint;
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
