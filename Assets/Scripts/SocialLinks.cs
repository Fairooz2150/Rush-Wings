using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SocialLinks : MonoBehaviour
{
   [SerializeField] AudioClip buttonSound;
    string linkedIn = "https://www.linkedin.com/in/muhammad-fairooz-0b1136268",
    email = "https://mail.google.com/mail/?view=cm&fs=1&to=fz.games001@gmail.com&su=Loved+your+game!+Want+to+discuss..&body=Hi+Fairooz,+I+would+like+to+contact+you+regarding+your+game.",
     website = "https://fairooz2150.github.io/FZ-Games";

    public void OpenLinkedIn()
    {
        Application.OpenURL(linkedIn);
    }
    public void OpenEmail()
    {
        Application.OpenURL(email);
    }
    public void OpenWebsite()
    {
        Application.OpenURL(website);
    }

    public void PlaySound()
    {
        UISoundManager.Play(buttonSound);
    }

}
