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
            Vector3 impulse = Vector3.zero;
            impulse = collision.transform.position;
            impulse.y *= 0.1f * collision.relativeVelocity.y;
            impulse.z *= 0.1f * collision.relativeVelocity.z;
            collision.transform.position = impulse;
            collision.collider.GetComponent<PlayerDamage>().UpdateDamage(damage);
        }

        hit += 1;
    }
}
