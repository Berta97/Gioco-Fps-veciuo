using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalBullet : BasicBullet
{
    // Update is called once per frame
    void Update()
    {
        transform.position -= transform.forward * Time.deltaTime * bulletSpeed;
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Player" && PhotonNetwork.isMasterClient)
        {
            Debug.Log("COLPITOOOOO!!!");
            collision.collider.GetComponent<PlayerDamage>().UpdateDamage(damage);
        }
        
        Destroy(gameObject);
    }
}
