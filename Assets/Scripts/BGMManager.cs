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
        BGM.DOKill();
        if (allowed)
        {
            if (!BGM.isPlaying)
            {
                BGM.volume = 0f;
                BGM.Play();
            BGM.DOFade(0.7f, 6f).SetUpdate(true);
            }
        }
        else
        {
            if (BGM.isPlaying)
            {

                BGM.DOFade(0f, 1.35f).SetUpdate(true).OnComplete(() => BGM.Stop());
            }
            // BGM.Stop();

        }
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

}
