using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayBGMController : MonoBehaviour
{
    [SerializeField] AudioSource BGM;
    [SerializeField] float fadeDuration = 2f;

    [SerializeField] UIManager uIManager;
    [SerializeField] ScoreManager scoreManager;

    bool hasStarted = false;
    bool paused = true;
    bool gameOverStarted = false;
    // Start is called before the first frame update
    void Start()
    {
        uIManager = GameObject.FindGameObjectWithTag("UI Manager").GetComponent<UIManager>();
        scoreManager = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreManager>();


        if (!hasStarted)
        {
            StartCoroutine(FadeInBGM());
            hasStarted = true;
        }

    }

    void Update()
    {
        if (uIManager.menuShowing)
        {
            PauseBGM();
        }
        else
        {
            ResumeBGM();
        }

        if (scoreManager.shownGameOver && !gameOverStarted)
        {
            StartCoroutine(GameOver());
            gameOverStarted = true;
        }
    }

    IEnumerator FadeInBGM()
    {
        BGM.volume = 0f;
        BGM.Play();

        float time = 0f;

        while (time < fadeDuration)
        {
            time += Time.unscaledDeltaTime;
            BGM.volume = Mathf.Lerp(0f, 0.5f, time / fadeDuration);
            yield return null;
        }
        BGM.volume = 0.5f;
    }
    // Update is called once per frame

    public void PauseBGM()
    {
        if (!paused)
        {

            BGM.Pause();
            paused = true;
        }
    }

    public void ResumeBGM()
    {
        if (paused)
        {

            BGM.UnPause();
            paused = false;
        }
    }

    IEnumerator GameOver()
    {
        float startVolume = BGM.volume;
        float time = 0f;

        while (time < 1f)
        {
            time += Time.unscaledDeltaTime;
            BGM.volume = Mathf.Lerp(startVolume, 0.1f, time / 1f);
            yield return null;
        }
        BGM
        .volume = 0.1f;
    }
}
