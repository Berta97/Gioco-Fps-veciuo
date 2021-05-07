using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;



public class CharacterSelection : Photon.MonoBehaviour
{
    public GameObject[] characters;
    public GameObject selectionPanel;
    public InputField nameField;

    private int selectedCharacter = 0;
    private int selectedSkin = 0;

    public void NextCharacter()
    {
        characters[selectedCharacter].SetActive(false);
        selectedCharacter = (selectedCharacter + 1) % characters.Length;
        characters[selectedCharacter].SetActive(true);

    }

    public void PreviousCharacter()
    {
        characters[selectedCharacter].SetActive(false);
        selectedCharacter--;
        
        if (selectedCharacter < 0)
        {
            selectedCharacter += characters.Length;

        }

        characters[selectedCharacter].SetActive(true);

    }
    
    public void StartGame()
    {

        if (nameField.text != "")
        {
            PhotonNetwork.player.NickName = nameField.text;


            PlayerPrefs.SetInt("selectedCharacter", selectedCharacter);
            SceneManager.LoadScene(2, LoadSceneMode.Single);

            PlayerInfo playerInfo = gameObject.GetComponent(typeof(PlayerInfo)) as PlayerInfo;

            playerInfo.model = selectedCharacter;
            playerInfo.skin = selectedSkin;
            playerInfo.SaveToString();
        }
    }

    public void NextSkin()
    {
        selectedSkin++;

        if (selectedSkin >= 7)
        {
            selectedSkin = 0;

        }

    }
}
