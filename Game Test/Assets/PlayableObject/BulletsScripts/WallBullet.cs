using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBullet : BasicBullet
{
    private int hit = 0;
    

    // Update is called once per frame
    void Update()
    {
        transform.position -= transform.forward * Time.deltaTime * bulletSpeed;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (hit == 3)
        {
            Destroy(gameObject);
        }

        if(collision.collider.tag == "Player" && PhotonNetwork.isMasterClient)
        {
            Debug.Log("COLPITOOOOO!!!");
            collision.collider.GetComponent<PlayerDamage>().UpdateDamage(damage);
        }

        hit += 1;
    }
}
