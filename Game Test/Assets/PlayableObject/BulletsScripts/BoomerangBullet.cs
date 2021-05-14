using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerangBullet : BasicBullet
{
    private float reversetime = 1f;
    private float currenttime = 0f;

    // Update is called once per frame
    void Update()
    {
        currenttime += Time.deltaTime;

        if(currenttime > reversetime)
        {
            bulletSpeed *= -1.1f;
        }

      

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
