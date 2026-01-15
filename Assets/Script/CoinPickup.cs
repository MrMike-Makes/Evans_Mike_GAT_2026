using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class CoinPickup : MonoBehaviour
{
    public AudioClip pickupSound;
    public AudioMixerGroup mixerGroup; // assign your SFX group here

    private AudioSource audioSource;

    void Start()
    {
        // Add an AudioSource only for reference if needed
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = pickupSound;
        audioSource.outputAudioMixerGroup = mixerGroup;
        audioSource.playOnAwake = false;
        audioSource.spatialBlend = 0f; // 0 = 2D, 1 = 3D
        audioSource.volume = 1f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            // CREATE TEMP AUDIO OBJECT
            GameObject tempAudio = new GameObject("TempAudio");
            tempAudio.transform.position = transform.position;

            AudioSource tempSource = tempAudio.AddComponent<AudioSource>();
            tempSource.clip = pickupSound;
            tempSource.outputAudioMixerGroup = mixerGroup;
            tempSource.spatialBlend = 0f; // 0 = 2D, 1 = 3D
            tempSource.volume = 1f;
            tempSource.Play();

            // Destroy the temp audio object after clip finishes
            Destroy(tempAudio, pickupSound.length);

            // Destroy the coin immediately
            Destroy(gameObject);
        }
    }
}
