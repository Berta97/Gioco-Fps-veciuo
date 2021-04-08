using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    public Material[] material;
    public int x = 0;
    Renderer rend;

    private GameObject Player;


    // Start is called before the first frame update
    void Start()
    {
        Player = Resources.Load("Player") as GameObject;
       rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[x];

                  

    }

    // Update is called once per frame
    void Update()
    {
        rend.sharedMaterial = material[x];

        ChangeColor newCol = Player.GetComponentInChildren(typeof(ChangeColor), true) as ChangeColor;
        newCol.x = x;
    }

    public void NextColor()
    {
        if(x<6)
        {
            x++;

        }
        else
        {
            x = 0;
        }
    }
}
