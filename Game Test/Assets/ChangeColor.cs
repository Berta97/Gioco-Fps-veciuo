using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    public Material[] material;
    public int x = 0;
    Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[x];    

    }

    // Update is called once per frame
    void Update()
    {
        rend.sharedMaterial = material[x];
    }

    public void NextColor()
    {
        x++;
        
        if(x>=7)
        {
            x = 0;

        }
        
    }
}
