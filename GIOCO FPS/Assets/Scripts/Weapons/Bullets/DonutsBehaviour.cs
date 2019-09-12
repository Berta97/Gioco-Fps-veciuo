using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonutsBehaviour : MonoBehaviour {

	[SerializeField] 
	float bulletSpeed = 25f;
	int damage;

	void Start()
	{
		if (PhotonNetwork.isMasterClient)
		{
			damage = Random.Range (20, 40);
		}

		Destroy(gameObject, 3f);
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

	}
}