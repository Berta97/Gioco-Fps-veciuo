using UnityEngine;
using Player.Weapon;
using System.Runtime.CompilerServices;

public class LightWeapon : Item, IShoot
{

    public void Start()
    {
        waponSound = GetComponent<AudioSource>();
    }

    public override Weapon ID
    {
        get
        {
            return Weapon.light;
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
        Instantiate(Resources.Load("Prefabs/Bullets/LightBullet"), transform.position, transform.rotation);
    }
}
