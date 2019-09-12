using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpawner : MonoBehaviour {

	public Transform weaponSlot;
	GameObject gunSpawned;

	float spawnDelay = 1f;
	float timePassed = 0f;

	public bool isShotgun = false;
	public bool isRocketLauncher = false;
	public bool isMedikit = false;
	public bool isCrossbow = false;
	public bool isBat = false;
	public bool isSniper = false;
	public bool isBasicRifle = false;
	public bool isMagic = false;
	public bool islancialame = false;
	public bool isDonutsLauncher = false;

	// Use this for initialization
	void Start () {
	if(PhotonNetwork.isMasterClient)
		SpawnWeapon ();
	}
	
	// Update is called once per frame
	void Update () {
		if(PhotonNetwork.isMasterClient && weaponSlot.childCount == 0 )
		{
			timePassed += Time.deltaTime;
			if(timePassed >= spawnDelay)
			{
				SpawnWeapon ();
				timePassed = 0f;
				spawnDelay = 10f;
			}
		}

			
		
	}
	void SpawnWeapon()
	{

		if (isShotgun)
		{
			gunSpawned = PhotonNetwork.Instantiate("ShotgunPickup", weaponSlot.position, weaponSlot.rotation, 0);
		}
		else if (isCrossbow)
		{
			gunSpawned = PhotonNetwork.Instantiate("CrossbowPickup", weaponSlot.position, weaponSlot.rotation, 0);
		}
		else if (isMagic)
		{
			gunSpawned = PhotonNetwork.Instantiate("MagicPickup", weaponSlot.position, weaponSlot.rotation, 0);
		}
		else if (isBat)
		{
			gunSpawned = PhotonNetwork.Instantiate("BatPickup", weaponSlot.position, weaponSlot.rotation, 0);
		}
		else if (isRocketLauncher)
		{
			gunSpawned = PhotonNetwork.Instantiate("RocketLauncherPickup", weaponSlot.position, weaponSlot.rotation, 0);
		}
		else if (isSniper)
		{
			gunSpawned = PhotonNetwork.Instantiate("SniperPickup", weaponSlot.position, weaponSlot.rotation, 0);
		}
		else if (isBasicRifle)
		{
			gunSpawned = PhotonNetwork.Instantiate("BasicRiflePickup", weaponSlot.position, weaponSlot.rotation, 0);
		}
		else if (isDonutsLauncher)
		{
			gunSpawned = PhotonNetwork.Instantiate("DonutsLauncherPickup", weaponSlot.position, weaponSlot.rotation, 0);
		}
		else if (isMedikit)
		{
			gunSpawned = PhotonNetwork.Instantiate("MedikitPickup", weaponSlot.position, weaponSlot.rotation, 0);
		}
		else if (islancialame)
		{
			gunSpawned = PhotonNetwork.Instantiate("lancialamePickup", weaponSlot.position, weaponSlot.rotation, 0);
		}
		gunSpawned.transform.parent = weaponSlot;
	}

}
