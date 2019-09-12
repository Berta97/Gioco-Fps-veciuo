using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponManager : Photon.MonoBehaviour {
	
	enum Weapons
	{
		basicRifle, rocketRifle, shotgun, crossbow, bat, sniper, magic, donutslauncher, medikit, lancialame
	};

	enum Ammo
	{
		basicAmmo = 0, rocket = 15, shotgunAmmo = 18, arrow = 20, bat = 10, sniper = 8, magic = 5, donutslauncher = 5, medikit = 1, lancialame = 10
	};

	PlayerShooting player;

	int weaponEnabled;
	int currentAmmo;


	public GameObject basicRifle;
	public GameObject rocketRifle;
	public GameObject medikit;
	public GameObject shotgun;
	public GameObject crossbow;
	public GameObject bat;
	public GameObject sniper;
	public GameObject magic;
	public GameObject lancialame;
	public GameObject donutslauncher;

	Text ammoText;


	// Use this for initialization
	void Start () {
		player = GetComponent<PlayerShooting> ();
		weaponEnabled = (int)Weapons.basicRifle;
		player.SetFireRate(0.2f);
		currentAmmo = 0;
		if (photonView.isMine)
		{
			ammoText = GameObject.FindGameObjectWithTag ("AmmoText").GetComponent<Text>();
			ammoText.text = "oo".ToString ();
		}
	}

	public int GetWeaponEnabled()
	{
		return weaponEnabled;
	}

	public GameObject GetGOEnabled()
	{
		switch (weaponEnabled)
		{
		case (0):
			return basicRifle;
		case (1):
			return rocketRifle;
		case (2):
			return shotgun;
		case (3):
			return crossbow;
		case (4):
			return bat;
		case (5):
			return sniper;
		case (6):
			return magic;
		case (7):
			return donutslauncher;
		case (8):
			return medikit;
		case (9):
			return lancialame;
		default:
			return basicRifle;
		}
	}

	public string GetBulletType(int weaponType)
	{
		switch (weaponType)
		{
		case (0):
			return "BasicBullet";
		case (1):
			return "RocketBullet";
		case (2):
			return "ShotgunBullet";
		case (3):
			return "Arrow";
		case (4):
			return "hit";
		case (5):
			return "SniperBullet";
		case (6):
			return "Zan";
		case (7):
			return "Donuts";
		case (8):
			return "Medikits";
		case (9):
			return "Lame";
		default:
			return "BasicBullet";
		}
	}
	public int GetAmmoFromIndex(int index)
	{
		switch (index)
		{
		case (0):
			return 0;
		case (1):
			return 8;
		case (2):
			return 15;
		case (3):
			return 20;
		case (4):
			return 10;
		case (5):
			return 8;
		case (6):
			return 5;
		case (7):
			return 5;
		case (8):
			return 1;
		case (9):
			return 10;
		default:
			return 0;
		}
	}

	public void Shooted()
	{
		if(weaponEnabled != 0)
		{
			currentAmmo--;
			ammoText.text =	currentAmmo.ToString ();

			if(currentAmmo == 0)
			{
				photonView.RPC ("DisableWeapon", PhotonTargets.AllBuffered, null);
				weaponEnabled = (int)Weapons.basicRifle;
				photonView.RPC("EnableWeapon", PhotonTargets.AllBuffered,weaponEnabled);
				player.SetFireRate(0.2f);
				ammoText.text = "oo".ToString();
			}
		}
	}
	void OnTriggerEnter(Collider col)
	{
		if (photonView.isMine)
		{
			if(col.tag == "RocketRifle")
			{
				photonView.RPC("DisableWeapon", PhotonTargets.AllBuffered, null);
				photonView.RPC ("EnableWeapon", PhotonTargets.AllBuffered, (int)Weapons.rocketRifle);
				player.SetFireRate (1.5f);
			}
			if(col.tag == "ShotgunRifle")
			{
				photonView.RPC("DisableWeapon", PhotonTargets.AllBuffered, null);
				photonView.RPC ("EnableWeapon", PhotonTargets.AllBuffered, (int)Weapons.shotgun);
				player.SetFireRate (0.4f);
			}
			if(col.tag == "Magic")
			{
				photonView.RPC("DisableWeapon", PhotonTargets.AllBuffered, null);
				photonView.RPC ("EnableWeapon", PhotonTargets.AllBuffered, (int)Weapons.magic);
				player.SetFireRate (2f);
			}
			if(col.tag == "Sniper")
			{
				photonView.RPC("DisableWeapon", PhotonTargets.AllBuffered, null);
				photonView.RPC ("EnableWeapon", PhotonTargets.AllBuffered, (int)Weapons.sniper);
				player.SetFireRate (2f);
			}
			if(col.tag == "Crossbow")
			{
				photonView.RPC("DisableWeapon", PhotonTargets.AllBuffered, null);
				photonView.RPC ("EnableWeapon", PhotonTargets.AllBuffered, (int)Weapons.crossbow);
				player.SetFireRate (1f);
			}
			if(col.tag == "Bat")
			{
				photonView.RPC("DisableWeapon", PhotonTargets.AllBuffered, null);
				photonView.RPC ("EnableWeapon", PhotonTargets.AllBuffered, (int)Weapons.bat);
				player.SetFireRate (0.2f);
			}
			if(col.tag == "DonutsLauncher")
			{
				photonView.RPC("DisableWeapon", PhotonTargets.AllBuffered, null);
				photonView.RPC ("EnableWeapon", PhotonTargets.AllBuffered, (int)Weapons.donutslauncher);
				player.SetFireRate (0.7f);
			}
			if(col.tag == "BasicRifle")
			{
				photonView.RPC("DisableWeapon", PhotonTargets.AllBuffered, null);
				photonView.RPC ("EnableWeapon", PhotonTargets.AllBuffered, (int)Weapons.basicRifle);
				player.SetFireRate (0.35f);
			}
			if(col.tag == "Medikit")
			{
				photonView.RPC("DisableWeapon", PhotonTargets.AllBuffered, null);
				photonView.RPC ("EnableWeapon", PhotonTargets.AllBuffered, (int)Weapons.medikit);
				player.SetFireRate (0.2f);
			}
			if(col.tag == "lancialame")
			{
				photonView.RPC("DisableWeapon", PhotonTargets.AllBuffered, null);
				photonView.RPC ("EnableWeapon", PhotonTargets.AllBuffered, (int)Weapons.lancialame);
				player.SetFireRate (0.6f);
			}
		}		
	}

	[PunRPC]
	void EnableWeapon(int index)
	{
		weaponEnabled = index;
		GetGOEnabled ().SetActive (true);
		currentAmmo = GetAmmoFromIndex (index);
		if (photonView.isMine)
		{
			ammoText.text = currentAmmo.ToString ();
		}
	}

	[PunRPC]
	void DisableWeapon()
	{
		GetGOEnabled ().SetActive (false);
	}
}