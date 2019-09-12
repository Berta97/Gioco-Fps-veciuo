using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillTextBehaviour : MonoBehaviour {

	string Killer;
	string victim;
	string KillMessage;

	public Text KillText;

	Animator anim;

	float timePassed;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		timePassed = 0f;	
	}
	
	// Update is called once per frame
	void Update () {
		if (anim.GetBool("NewDead"))
		{
			timePassed += Time.deltaTime;
			if(timePassed > 2f)
			{
				anim.SetBool ("NewDead", false);
				anim.SetBool ("Reverse", true);
				timePassed = 0f;
			}
		}
	}
	public void SetKillerAndVictim(string kName, string vName)
	{
		if(kName == null)
		{
			victim = vName;
			KillMessage = victim + " committed suicide.";
		}
		else
		{
			Killer = kName;
			victim = vName;
			KillMessage = Killer + " has killed " + victim + ".";
		}

		KillText.text = KillMessage;

		if (anim.GetBool("NewDead"))
			{
				timePassed = 0f;
			}
			else
			{
				anim.SetBool("Reverse", false);
				anim.SetBool("NewDead", true);
			}
	}
}
