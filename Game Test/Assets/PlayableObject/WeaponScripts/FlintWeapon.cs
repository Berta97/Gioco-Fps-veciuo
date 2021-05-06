using Player.Weapon;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlintWeapon : Item, IShoot
{
    AudioSource m_bastonataSound;

    public void Start()
    {
        m_bastonataSound = GetComponent<AudioSource>();
    }

    public void Shoot()
    {
        Debug.Log("TAGLIO TUTTO!!");
        m_bastonataSound.Play();
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
