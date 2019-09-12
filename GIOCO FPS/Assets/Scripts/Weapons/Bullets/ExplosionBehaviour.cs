using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionBehaviour : MonoBehaviour {
	float lifeTime = 1f;
	float timePassed = 0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		timePassed += Time.deltaTime;
		if(timePassed >= lifeTime)
		{
			Destroy (gameObject);
		}
	}
}
