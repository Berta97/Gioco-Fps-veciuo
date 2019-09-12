using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZanBehaviour : MonoBehaviour {

	[SerializeField] 
	float bulletSpeed = 50f;
	int damage;

	void Start()
	{
		if (PhotonNetwork.isMasterClient)
		{
			damage = Random.Range (50, 75);
		}

		Destroy(gameObject, 6f);
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