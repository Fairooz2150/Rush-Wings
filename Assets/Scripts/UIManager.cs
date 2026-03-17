using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject pauseBtn, pauseMenu;
    bool menuShowing = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowPauseMenu()
    {
        menuShowing = !menuShowing;
        if (menuShowing)
        {

            pauseMenu.SetActive(true);
            pauseBtn.SetActive(false);
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
            pauseMenu.SetActive(false);
            pauseBtn.SetActive(true);
            
        }
    }

    public void Home()
    {
        Debug.Log("Home..");
    }

}
