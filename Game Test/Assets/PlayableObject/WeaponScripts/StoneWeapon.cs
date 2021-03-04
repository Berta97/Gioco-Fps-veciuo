using UnityEngine;
using Player.Weapon;
using System.Runtime.CompilerServices;

public class StoneWeapon : Item, IShoot
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

    public void Shoot()
    {
        photonView.RPC("InstantiateBullet", PhotonTargets.AllBuffered);
    }


    [PunRPC]
    void InstantiateBullet()
    {
        Instantiate(Resources.Load("Prefabs/Bullets/StoneBullet"), transform.position, transform.rotation);
    }
}
