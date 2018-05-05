using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeImage : MonoBehaviour
{
    public bool fadeInAndOut, fadeIn, fadeOut, fadeInOnTrigger; 
    public float stayDuration, fadeSpeed;
    public float delay;  

    public void Start()
    {
        transform.GetComponent<Image>().CrossFadeAlpha(0, 0, false);
        if (!fadeInOnTrigger)
        {
            startFade(delay); 
        }

    }
    public void startFade(float p_delay)
    {
        Invoke("startFade", p_delay);
    }

    public void startFade()
    {
        if (fadeInAndOut)
        {
            StartCoroutine(fadeImageInAndOut());
        }
        else if (fadeIn)
        {
            fadeImage(transform.GetComponentsInChildren<Image>(), false);
        }
        else if (fadeOut)
        {
            fadeImage(transform.GetComponentsInChildren<Image>(), true);
        }
    }
    public IEnumerator fadeImageInAndOut()
    {
        while (true)
        {
            fadeImage(transform.GetComponentsInChildren<Image>(), false);
            yield return new WaitForSeconds(fadeSpeed);
            yield return new WaitForSeconds(stayDuration);
            fadeImage(transform.GetComponentsInChildren<Image>(), true);
            yield return new WaitForSeconds(fadeSpeed);
            yield return new WaitForSeconds(stayDuration);
        }
    }

    public void fadeImage(Image[] images, bool fadeAway)
    {
        // fade from opaque to transparent
        if (fadeAway)
        {
            foreach (Image img in images) {
                img.CrossFadeAlpha(0, fadeSpeed, false);
            }
        }
        // fade from transparent to opaque
        else
        {
            // loop over 1 second
            foreach(Image img in images) {
                img.CrossFadeAlpha(0, 0, false); 
                img.CrossFadeAlpha(1, fadeSpeed, false);
            }
        }
    }
}