using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDamage : Photon.MonoBehaviour
{
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
                currentHealth = 0;
                PhotonNetwork.Destroy(gameObject);
            }
            healthText.text = currentHealth.ToString();
        }
    }

    public void UpdateDamage(int damage)
    {
        photonView.RPC("ApplyDamage", PhotonTargets.AllViaServer, damage);
    }

    [PunRPC]
    void ApplyDamage(int damage)
    {
        currentHealth -= damage;
    }

}
