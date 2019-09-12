using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour {

	[SerializeField] 
	float bulletSpeed = 20f;
	int damage;

	void Start()
	{
		if (PhotonNetwork.isMasterClient)
		{
			damage = Random.Range (20, 30);
		}

		Destroy(gameObject, 4f);
	}


	// Use this for initialization
	void Update () {
		transform.position += transform.forward * Time.deltaTime * bulletSpeed;

	}


	void OnCollisionEnter(Collision col)
	{
		if (col.collider.tag == "Player" && PhotonNetwork.isMasterClient)
		{
			col.collider.GetComponent<PlayerDamage>().GetDamage(damage,gameObject.name);
		}
		Destroy(gameObject);

	}
}