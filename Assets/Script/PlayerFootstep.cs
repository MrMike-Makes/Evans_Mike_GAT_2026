using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFootstep : MonoBehaviour
{
    [SerializeField, Range(0, 1)] float minVolume = 0.4f;
    [SerializeField, Range(0, 1)] float maxVolume = 0.6f;
    [SerializeField, Range(-3, 3)] float minPitch = 0.8f;
    [SerializeField, Range(-3, 3)] float maxPitch = 1.3f;


    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip[] clips;

    void PlayFootstepSound()
    {
        float randNum = Random.Range(minVolume, maxVolume);

        audioSource.volume = randNum;

        randNum = Random.Range(minPitch, maxPitch);

        audioSource.pitch = randNum;

        audioSource.PlayOneShot(clips[PlayerController.instance.footstepClip]);
    }
}
