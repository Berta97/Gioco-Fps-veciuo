using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerangBullet : BasicBullet
{
    private float reversetime = 1.5f;
    private float currenttime = 0f;
    private bool reverse = false;
    // Update is called once per frame
    void Update()
    {
        currenttime += Time.deltaTime;

        if(currenttime > reversetime && !reverse)
        {
            bulletSpeed *= -1f;
            reverse = true;
        }


        transform.position -= transform.forward * Time.deltaTime * bulletSpeed;
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
