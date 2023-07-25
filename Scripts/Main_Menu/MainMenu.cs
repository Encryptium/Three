using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button resetBtn;
    public GameObject resetMessage;
    public GameObject HTP;

    void Update() {
        // Debug.Log(PlayerPrefs.GetInt("Level"));
        if (PlayerPrefs.GetInt("Level") == 0) {
            resetBtn.interactable = false;
        }
    }

    public void startGame() {
        SceneManager.LoadScene(1); // Load index 1 scene (Game)
    }

    public void resetMemory() {
        PlayerPrefs.SetInt("Level", 0);
        Instantiate(resetMessage);
    }

    public void howToPlay() {
        // Debug.Log("How to play menu opening.");
        Instantiate(HTP);
    }
}
