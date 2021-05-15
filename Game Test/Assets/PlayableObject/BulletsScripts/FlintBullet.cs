using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlintBullet : BasicBullet
{

    private float timePassed = 0;

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;
        if(timePassed < lifeTime)
        {
            transform.position -= transform.forward * Time.deltaTime * bulletSpeed;
        }
        else
        {
            Destroy(gameObject);
        }
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
