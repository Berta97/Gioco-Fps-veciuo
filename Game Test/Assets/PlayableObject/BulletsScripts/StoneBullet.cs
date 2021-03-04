using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneBullet : BasicBullet
{
    // Update is called once per frame
    void Update()
    {
        transform.position -= transform.forward * Time.deltaTime * bulletSpeed;
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("COLPITOOOOO!!!");
        Destroy(gameObject);
    }
}
