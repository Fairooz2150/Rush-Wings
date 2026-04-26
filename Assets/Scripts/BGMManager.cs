using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMManager : MonoBehaviour
{

    public static BGMManager instance;
    // private string[] allowedScenes = { "About Scene", "Main Menu" };
    public AudioSource BGM;
    private HashSet<string> allowedScenes = new HashSet<string>
    {
        "About Scene", "Main Menu"
    };
    void Awake()
    {

        if (BGM == null)
        {
            BGM = GetComponent<AudioSource>();
        }


        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;

        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;

    }
    void Start()
    {
        OnSceneLoaded(SceneManager.GetActiveScene(), LoadSceneMode.Single);
    }


    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        bool allowed = allowedScenes.Contains(scene.name);
        if (allowed && !BGM.isPlaying)
        {
            BGM.volume=0.5f;
            BGM.Play();
        }
        else if (!allowed && BGM.isPlaying)
        {
            // BGM.Stop();
            BGM.DOFade(0f,1.35f).OnComplete(()=>BGM.Stop());

        }
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

}
