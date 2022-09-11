using System.Collections;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    private AudioSource source;
    private float fadingSpeed = 0.1f;
    private float maxVolume = 1f;
    private bool keepFadingIn;
    private bool keepFadingOut;
    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }
    public void ToggleMusic() //float fadingSpeed, float maxVolume
    {
        if (source.volume == 0)
        {
            StartCoroutine(FadeIn(fadingSpeed, maxVolume));
        }
        else if (source.volume > 0)
        {
            StartCoroutine(FadeOut(fadingSpeed));
        }
    }
    private IEnumerator FadeIn(float fadingSpeed, float maxVolume)
    {
        keepFadingIn = true;
        keepFadingOut = false;
        source.volume = 0;
        float audioVolume = source.volume;

        while (source.volume < maxVolume && keepFadingIn)
        {
            audioVolume += fadingSpeed;
            source.volume = audioVolume;
            yield return new WaitForSeconds(0.1f);
        }
      
    }
    private IEnumerator FadeOut(float fadingSpeed)
    {
        keepFadingOut = true;
        keepFadingIn = false;
        float audioVolume = source.volume;

        while (source.volume > 0 && keepFadingOut)
        {
            audioVolume -= fadingSpeed;
            source.volume = audioVolume;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
