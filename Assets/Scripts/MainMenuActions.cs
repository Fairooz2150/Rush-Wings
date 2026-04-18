using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuActions : MonoBehaviour
{
    
    public void PlayGame()
    {
        SceneManager.LoadScene("Game Play");
    }

    public void OpenAbout()
    {
        SceneManager.LoadScene("About Scene");
    }

    public void QuitGame()
    {
        Debug.Log("Game is exiting");
        Application.Quit();
    }
}
