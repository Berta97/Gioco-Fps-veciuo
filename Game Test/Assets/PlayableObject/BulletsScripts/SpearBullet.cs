using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearBullet : BasicBullet
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
            Vector3 impulse = Vector3.zero;
            impulse = collision.transform.position;
            impulse.y *= 0.1f * collision.relativeVelocity.y;
            impulse.z *= 0.1f * collision.relativeVelocity.z;
            collision.transform.position = impulse;
            collision.collider.GetComponent<PlayerDamage>().UpdateDamage(damage);
        }
        
        Destroy(gameObject);
    }
}
