using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupBehaviour : MonoBehaviour {
	

	// Use this for initialization
	void Update () {
	transform.Rotate(transform.up * Time.deltaTime * 20f);
	}


	void OnTriggerEnter(Collider col)
	{
		if(col.tag == "Player")
		{
			PhotonNetwork.Destroy(gameObject);
		}
	}
}
