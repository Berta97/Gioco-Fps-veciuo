using UnityEngine;
using Player.Weapon;
using System.Runtime.CompilerServices;

public class StoneWeapon : Item, IShoot
{
    AudioSource m_bastonataSound;

    public void Start()
    {
        m_bastonataSound = GetComponent<AudioSource>();
    }

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
        m_bastonataSound.Play();
    }


    [PunRPC]
    void InstantiateBullet()
    {
        Instantiate(Resources.Load("Prefabs/Bullets/StoneBullet"), transform.position, transform.rotation);
    }
}
