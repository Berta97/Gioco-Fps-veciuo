using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerNetwork : Photon.MonoBehaviour
{
    [SerializeField]
    public Camera playerCamera;

    [SerializeField]
    public AudioListener playerListener;

    [SerializeField]
    public GameObject hud;

    // Start is called before the first frame update
    void Start()
    {
        if (photonView.isMine)
        {
            playerCamera.enabled = true;
            playerListener.enabled = true;
            GetComponent<FirstPersonController>().enabled = true;
            GetComponent<SwitchToActive>().enabled = true;
            GetComponent<ExtractMaterial>().enabled = true;
            hud.SetActive(true);
        }
    }

}
