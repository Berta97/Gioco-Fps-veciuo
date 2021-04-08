using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class CharacterSelection : MonoBehaviour
{
    public GameObject[] characters;
    public int selectedCharacter = 0;

    private GameObject Player;

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
        PlayerPrefs.SetInt("selectedCharacter", selectedCharacter);
        SceneManager.LoadScene(2, LoadSceneMode.Single);

        FirstPersonController fpc = Player.gameObject.GetComponent(typeof(FirstPersonController)) as FirstPersonController;
        fpc.selectedcharacter = selectedCharacter;
        

    }

    public void Start()
    {
        Player = Resources.Load("Player") as GameObject;
    }
}
