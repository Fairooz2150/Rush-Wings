using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISoundManager : MonoBehaviour
{

    public static UISoundManager instance;

    [SerializeField] AudioSource uiAudioSource;
    // Start is called before the first frame update
    void Awake()
    {
        if(instance != null&& instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);

        if(uiAudioSource==null)
        uiAudioSource = GetComponent<AudioSource>();
    }

   public void PlaySound(AudioClip clip)
    {
        if(clip!= null)
        {
            uiAudioSource.PlayOneShot(clip);
        }
    }

    public static void Play(AudioClip clip)
    {
        if(instance != null)
        {
            instance.PlaySound(clip);
        }
    }
}
