using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDamage : Photon.MonoBehaviour
{
    private float ragdoltime = 4f;
    private float currenttime = 0f;

    [SerializeField] public int playerHealth;

    private Text healthText;

    private int currentHealth = 0;

    // Start is called before the first frame update
    void Start()
    {
        healthText = GameObject.FindGameObjectsWithTag("HealthText")[0].GetComponent<Text>();
        currentHealth = playerHealth;
    }

    // Update is called once per frame
    void Update()
    {


        if (photonView.isMine)
        {
            if (currentHealth <= 0)
            {
                currenttime += Time.deltaTime;
                if(currenttime > ragdoltime)
                {
                    currentHealth = 0;
                    NetworkManager.netManager.PlayerIsDead();
                    PhotonNetwork.Destroy(gameObject);
                }
                else
                {
                    GetComponent<Rigidbody>().isKinematic = false;
                }
            }
            healthText.text = currentHealth.ToString();
        }
    }

    public void UpdateDamage(int damage)
    {
        photonView.RPC("ApplyDamage", PhotonTargets.AllViaServer, damage);
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "EndMap" && photonView.isMine)
        {
            currentHealth = 0;
        }
    }

    [PunRPC]
    void ApplyDamage(int damage)
    {
        currentHealth -= damage;
    }

}
