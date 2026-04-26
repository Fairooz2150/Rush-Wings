using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuActions : MonoBehaviour
{
    [SerializeField] AudioClip clickSound;

    public void PlayGame()
    {
        SceneManager.LoadScene("Game Play");

        PlaySound();
    }

    public void OpenAbout()
    {
        SceneManager.LoadScene("About Scene");
        PlaySound();

    }

    public void QuitGame()
    {
        PlaySound();
        Debug.Log("Game is exiting");
        Application.Quit();
    }

    public void MainMenu()
    {
        PlaySound();
        SceneManager.LoadScene("Main Menu");
    }

    public void PlaySound()
    {
        UISoundManager.Play(clickSound);

    }
}
