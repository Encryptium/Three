using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public void returnMenu() 
    {
        SceneManager.LoadScene(0); // Loda the main menu screen.
    }
}
