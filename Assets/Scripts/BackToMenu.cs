using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour
{
  [SerializeField] AudioClip buttonSound;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MainMenu();
        }
    }

     public void MainMenu()
    {
        UISoundManager.Play(buttonSound);
        SceneManager.LoadScene("Main Menu");
    }
}
