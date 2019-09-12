using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedikitBehaviour : MonoBehaviour {

	[SerializeField] 
	float bulletSpeed = 25f;
	int	heal;

	void Start()
	{
		if (PhotonNetwork.isMasterClient)
		{
			heal = Random.Range (-30, -50);
		}

		Destroy(gameObject, 2f);
	}


	// Use this for initialization
	void Update () {
		transform.position += transform.forward * Time.deltaTime * bulletSpeed;

	}


	void OnCollisionEnter(Collision col)
	{
		if (col.collider.tag == "Player" && PhotonNetwork.isMasterClient)
		{
			col.collider.GetComponent<PlayerDamage>().GetDamage(heal,gameObject.name);
		}
		Destroy(gameObject);

	}
}