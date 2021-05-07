﻿using Player.Weapon;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickWeapon : Item, IShoot
{

    private bool isShoot = false;
    private float timeAction = 0.5f;

    public void Start()
    {
        waponSound = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(isShoot == true)
        {
            if(timeAction <= 0) 
            {
                isShoot = false;
            }
            timeAction -= Time.deltaTime;
        }
    }
    public void Shoot()
    {
        waponSound.Play();
        isShoot = true;
        timeAction = 0.5f;
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

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player" && isShoot && PhotonNetwork.isMasterClient)
        {
            Debug.Log("MAZZOLATA!!!");
            collision.collider.GetComponent<PlayerDamage>().UpdateDamage(damage);
            isShoot = false;
        }
    }
}
