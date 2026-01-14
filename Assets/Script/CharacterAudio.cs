using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class CharacterAudio : MonoBehaviour
{
    void Awake()
    {
        AudioSource audio = GetComponent<AudioSource>();

        audio.spatialBlend = 1f;   // Full 3D sound
        audio.loop = true;

        if (!audio.isPlaying && audio.clip != null)
            audio.Play();
    }
}
