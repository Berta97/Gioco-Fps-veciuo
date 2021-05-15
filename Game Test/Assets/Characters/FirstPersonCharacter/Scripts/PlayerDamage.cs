using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerDamage : Photon.MonoBehaviour
{
    private float ragdoltime = 4f;
    private float currenttime = 0f;

    [SerializeField] public int playerHealth;
    [SerializeField] public Animator[] modelAnimators ;
    [SerializeField] public Camera cam;

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
                GetComponent<FirstPersonController>().enabled = false;
                GetComponent<ExtractMaterial>().enabled = false;
                if (currenttime > ragdoltime)
                {
                    currentHealth = 0;
                    NetworkManager.netManager.PlayerIsDead();
                    PhotonNetwork.Destroy(gameObject);
                }
                else
                {
                    currentHealth = 0;

                    Vector3 pos = cam.transform.position;
                    Quaternion q = cam.transform.rotation;
                    q.eulerAngles = new Vector3(90, 0, 0);
                    pos.y += 0.5f;
                    cam.transform.position = pos;
                    cam.transform.rotation = q;

                    foreach (Animator a in modelAnimators)
                        a.SetBool("IsDeath", true);
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
