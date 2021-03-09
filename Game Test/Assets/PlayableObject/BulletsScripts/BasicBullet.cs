﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBullet : Photon.MonoBehaviour
{
    [SerializeField] protected float bulletSpeed = 2f;
    [SerializeField] protected int damage = 10;
}