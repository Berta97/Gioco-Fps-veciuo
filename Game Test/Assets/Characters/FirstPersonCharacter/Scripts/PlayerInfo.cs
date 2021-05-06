using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public int model = 0;
    public int skin = 0;

    private FileStream fs;
    private void Start()
    {
        var systemPath = System.Environment.
                             GetFolderPath(
                                 Environment.SpecialFolder.CommonApplicationData
                             );
        var complete = Path.Combine(systemPath, "VillaGame.json");
        fs = File.Create(complete);
    }
    public void SaveToString()
    {

        string json = JsonUtility.ToJson(this);
        byte[] bytes = Encoding.UTF8.GetBytes(json);
        fs.Write(bytes, 0, bytes.Length);
        fs.Close();
    }

    

}

[System.Serializable]
public class PlayerStats
{
    public int model = 0;
    public int skin = 0;

    public static PlayerStats CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<PlayerStats>(jsonString);
    }
}
