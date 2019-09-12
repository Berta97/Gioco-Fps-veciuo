using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Player1Network : Photon.MonoBehaviour {

	public Camera myCamera;
	public AudioListener listener;

	// Use this for initialization
	void Start () {
		if (photonView.isMine)
		{
			myCamera.enabled = true;
			listener.enabled = true;
			GetComponent<FirstPersonController>().enabled = true;
		}
	}
}

