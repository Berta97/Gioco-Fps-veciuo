using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : Photon.MonoBehaviour {

	public Transform firePoint;
	public Transform ShellPoint;
	public ParticleSystem muzzle;

	WeaponManager weapons;

	float fireRate = 0.3f;
	float timePassed = 0f;

	public AudioClip normal, shotgun, rocket, arrow, hit, sniper, magic, donuts, medikits, lancialame;
	AudioSource source;

	// Use this for initialization
	void Start () {
		weapons = GetComponent<WeaponManager> ();	
		source = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		timePassed += Time.deltaTime;
		if (photonView.isMine && Input.GetMouseButton(0) && timePassed >= fireRate)
		{
			Shooting();
		}
	}
	void Shooting()
	{
		int weaponType = weapons.GetWeaponEnabled ();
		string bulletType = weapons.GetBulletType (weaponType);
		weapons.Shooted(); 
		photonView.RPC("InstantiateBullet",PhotonTargets.All, bulletType,firePoint.position,firePoint.rotation,photonView.owner.name,weaponType);
		timePassed = 0f;
	}

	[PunRPC]
	void InstantiateBullet(string bullet, Vector3 pos, Quaternion rot,string playerName,int weaponType)
	{
		GameObject projectile = (GameObject)Instantiate(Resources.Load(bullet), pos, rot);
		projectile.name = playerName;
		Instantiate(Resources.Load ("Shell"), ShellPoint.position, ShellPoint.rotation);

		if (weaponType == 0)
		{
			source.clip = normal;
		}
		else if(weaponType == 1)
		{
			source.clip = rocket;
		}
		else if(weaponType == 2)
		{
			source.clip = shotgun;
		}	
		else if(weaponType == 3)
		{
			source.clip = arrow;
		}
		else if(weaponType == 4)
		{
			source.clip = hit;
		}
		else if(weaponType == 5)
		{
			source.clip = sniper;
		}
		else if(weaponType == 6)
		{
			source.clip = magic;
		}
		else if(weaponType == 7)
		{
			source.clip = donuts;
		}
		else if(weaponType == 8)
		{
			source.clip = medikits;
		}
		else if(weaponType == 9)
		{
			source.clip = lancialame;
		}
		muzzle.Play ();
		if (!source.isPlaying)
		{
			source.Play ();
		}
	}
	public void SetFireRate(float newValue)
	{
		fireRate = newValue;
	}
}