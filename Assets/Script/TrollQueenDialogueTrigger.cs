using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrollQueenDialogueTrigger : MonoBehaviour
{
    public AudioSource trollAudio;
    public AudioSource demonDollAudio;

    public float fadeOutDuration = 0.5f; // fade duration in seconds

    private void Start()
    {
        trollAudio.Stop();
        demonDollAudio.Stop();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            // Reset playback time for perfect sync
            trollAudio.time = 0f;
            demonDollAudio.time = 0f;

            // Start both audios on the same frame
            trollAudio.Play();
            demonDollAudio.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            // Smooth fade out on exit
            StartCoroutine(FadeOutAudio(trollAudio, fadeOutDuration));
            StartCoroutine(FadeOutAudio(demonDollAudio, fadeOutDuration));
        }
    }

    // Coroutine for smooth fade-out
    private IEnumerator FadeOutAudio(AudioSource source, float duration)
    {
        float startVolume = source.volume;
        float time = 0f;

        while (time < duration)
        {
            time += Time.deltaTime;
            source.volume = Mathf.Lerp(startVolume, 0, time / duration);
            yield return null;
        }

        source.Stop();
        source.volume = startVolume; // reset volume for next play
    }
}
