using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject pauseBtn, pauseMenu;
    public TouchArea touchArea;
    [SerializeField] private BirdScript birdScript;
    [SerializeField] AudioClip pauseSound, homeButtonSound;
    public Animator instructionAnimation, shootInstrAnim;
    public UIManager uIManager;
    public bool menuShowing = false;

    // Start is called before the first frame update
    void Start()
    {
        touchArea = GameObject.FindGameObjectWithTag("Touch Area").GetComponent<TouchArea>();
        birdScript = GameObject.FindGameObjectWithTag("Player").GetComponent<BirdScript>();

        instructionAnimation.updateMode = AnimatorUpdateMode.UnscaledTime;
        // shootInstrAnim.updateMode = AnimatorUpdateMode.UnscaledTime;
        // StartCoroutine(StartShootInstrAnim());

    }

    // Update is called once per frame
    void Update()
    {
        bool birdIsAlive = birdScript.birdIsAlive;

        if(Input.GetKeyDown(KeyCode.Escape) && birdIsAlive)
        {
            ShowPauseMenu();
        }
        
        if (Time.timeScale == 0f)
        {
            if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return) || touchArea.isTouching) && menuShowing)
            {
                ShowPauseMenu();
            }
        }
       
    }

//  IEnumerator StartShootInstrAnim()
//     {
//         yield return new WaitForSeconds(0.5f);
//         if (shootInstrAnim)
//         {
//             shootInstrAnim.SetTrigger("Start");
//         }
//     }
    public void ShowPauseMenu()
    {
        UISoundManager.Play(pauseSound);
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
        UISoundManager.Play(homeButtonSound);
        SceneManager.LoadScene("Main Menu");
    }

}
