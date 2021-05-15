using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class NetworkManager : Photon.MonoBehaviour
{

    public static NetworkManager netManager;

    [SerializeField]
    public Transform[] spawnPoint;
    [SerializeField]
    public Text respawnText;
    [SerializeField]
    public Image map;
    [SerializeField]
    public float spawnDelay = 3f;
    [SerializeField]
    public Camera cameraIntro;


    private bool isDead = false;
    private float timeNeeded = 0f;


    // Start is called before the first frame update
    void Start()
    {
        netManager = this;
        timeNeeded = spawnDelay;
        cameraIntro.gameObject.SetActive(true);
        map.gameObject.SetActive(false);
        PhotonNetwork.autoJoinLobby = true;
        PhotonNetwork.ConnectUsingSettings("FPS Test version 1");

    }

    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 100), PhotonNetwork.connectionStateDetailed.ToString());
    }

    void Update()
    {
        if (isDead)
        {
            cameraIntro.gameObject.SetActive(true);
            map.gameObject.SetActive(false);
            respawnText.text = "Respawning..." + Mathf.Round(timeNeeded);
            timeNeeded -= Time.deltaTime;
            if(timeNeeded < 0.5f)
            {
                isDead = false;
                timeNeeded = spawnDelay;
                respawnText.gameObject.SetActive(false);
                RespawnPlayer();
            }
        }
        
    }

    void OnJoinedLobby()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    void OnPhotonRandomJoinFailed()
    {
        PhotonNetwork.CreateRoom(null);
    }

    void OnJoinedRoom()
    {

        PlayerIsDead();
    }

    void RespawnPlayer()
    {
        Transform pos = spawnPoint[UnityEngine.Random.Range(0, spawnPoint.Length)];
        GameObject player = PhotonNetwork.Instantiate("Player", pos.position, pos.rotation,0);
        SkinManager sm = player.GetComponent(typeof(SkinManager)) as SkinManager;
        sm.SetSkin();
        cameraIntro.gameObject.SetActive(false);
        map.gameObject.SetActive(true);
    }

    public void PlayerIsDead()
    {
        isDead = true;
        respawnText.gameObject.SetActive(true);
    }

    
}
