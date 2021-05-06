using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class SkinManager : Photon.MonoBehaviour
{
    private PlayerStats playerInfo;
    public void SetSkin()
    {
        var systemPath = System.Environment.
                             GetFolderPath(
                                 Environment.SpecialFolder.CommonApplicationData
                             );
        var complete = Path.Combine(systemPath, "VillaGame.json");
        string info = File.ReadAllText(complete, Encoding.UTF8);
        playerInfo = PlayerStats.CreateFromJSON(info);

        photonView.RPC("ApplySkin", PhotonTargets.AllBuffered, playerInfo.model, playerInfo.skin);
    }
    
    
    [PunRPC]
    void ApplySkin(int model, int skin)
    {

        GameObject mod = gameObject.transform.GetChild(5).GetChild(model).gameObject;
        mod.SetActive(true);
        ChangeColor col = mod.GetComponentInChildren(typeof(ChangeColor)) as ChangeColor;
        col.x = skin;
    }
}
