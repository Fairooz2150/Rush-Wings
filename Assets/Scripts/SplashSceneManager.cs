using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SplashSceneManager : MonoBehaviour
{

    [SerializeField] Image companyLogo;
    [SerializeField] Image gamePoster;

    [SerializeField] float fadeDuration = 1.5f;
    [SerializeField] float displayTime = 2f;
    void Start()
    {
        StartCoroutine(PlaySplashSequence());
    }



    IEnumerator PlaySplashSequence()
    {
        //both image start invisible
        companyLogo.color = new Color(1, 1, 1, 0);
        gamePoster.color = new Color(1, 1, 1, 0);

        //Company Logo
        yield return FadeIn(companyLogo);
        yield return new WaitForSeconds(displayTime);
        yield return FadeOut(companyLogo);

        //Game Poster
        yield return FadeIn(gamePoster);
        yield return new WaitForSeconds(displayTime);
        yield return FadeOut(gamePoster);

        //Load Main menu
        SceneManager.LoadScene("Main Menu");

    }


    IEnumerator FadeIn(Image img)
    {
        bool done = false;
        img.DOFade(1f, fadeDuration).OnComplete(() => done = true);
        yield return new WaitUntil(() => done);
    }

    IEnumerator FadeOut(Image img)
    {
        bool done = false;
        img.DOFade(0f, fadeDuration).OnComplete(()=> done = true);
        yield return new WaitUntil(()=> done);

        img.gameObject.SetActive(false);
    }
}
