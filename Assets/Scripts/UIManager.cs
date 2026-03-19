using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject pauseBtn, pauseMenu;
    public TouchArea touchArea;
    public Animator instructionAnimation;
    bool menuShowing = false;

    // Start is called before the first frame update
    void Start()
    {
        touchArea = GameObject.FindGameObjectWithTag("Touch Area").GetComponent<TouchArea>();

        instructionAnimation.updateMode = AnimatorUpdateMode.UnscaledTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0f)
        {
            if ((Input.GetKeyDown(KeyCode.Space) || touchArea.isTouching) && menuShowing)
            {
                ShowPauseMenu();
            }
        }
       
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
