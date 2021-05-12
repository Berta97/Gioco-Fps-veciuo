using Player.Weapon;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.CompilerServices;

public class MetalWeapon : Item, IShoot
{

    public void Start()
    {
        waponSound = GetComponent<AudioSource>();
    }

    public override Weapon ID
    {
        get
        {
            return Weapon.metal;
        }
    }

    public override Sprite Image
    {
        get
        {
            return _image;
        }
    }

    public void Shoot()
    {
        waponSound.Play();
        photonView.RPC("InstantiateBullet", PhotonTargets.AllBuffered);
    }


    [PunRPC]
    void InstantiateBullet()
    {
        Instantiate(Resources.Load("Prefabs/Bullets/MetalBullet"), transform.position, transform.rotation);
    }
}
