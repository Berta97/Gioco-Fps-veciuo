using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDamage : Photon.MonoBehaviour {

	int health;
	Text healthText;


	GameObject KillText;


	string possibleKiller;
	bool suicide = false;

	// Use this for initialization
	void Start () {
		if (photonView.isMine)
		{
			KillText = GameObject.FindGameObjectWithTag ("KillText");
			health = 100;
			healthText = GameObject.FindGameObjectWithTag ("HealthText").GetComponent<Text>();
			healthText.text = health.ToString ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(photonView.isMine && health <= 0)
		{
			healthText.text = "0".ToString ();
			NetworkManager.netManager.PlayerIsDead ();
			PhotonNetwork.Destroy (gameObject);
		}
	}
	public void GetDamage(int damage, string name)
	{
		photonView.RPC("ApplyDamage", PhotonTargets.AllViaServer, damage,name);
	}


	[PunRPC]
	void ApplyDamage(int dmg, string name)
	{
		health -= dmg;
		possibleKiller = name;
		if (photonView.isMine)
		{
			healthText.text = health.ToString ();
		}
	}

	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.tag == "EndMap")
		{
			suicide = true;
			health = 0;
		}
	}

	void OnDestroy()
	{
		if (suicide)
		{
			KillText.GetComponent<KillTextBehaviour>().SetKillerAndVictim(null, photonView.owner.name);
		}
		else
		{
			KillText.GetComponent<KillTextBehaviour>().SetKillerAndVictim(possibleKiller, photonView.owner.name);
		}
	}

}
