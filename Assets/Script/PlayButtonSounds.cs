using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButtonSounds : MonoBehaviour
{
    // Current button ID
    public int thisButton;

    public static int currentButton; // records the ID of the button that the latest MouseDown event has occured over

    // the audiosource attached to the canvas
    public AudioSource audioSource;

    // three audioclips for the hover, mouse_down and mouse up audio files
    public AudioClip mouseHover;
    public AudioClip mouseDown;
    public AudioClip mouseUp;

    // Hover sound
    public void Play_MouseHover()
    {
        if (mouseHover != null)
            audioSource.PlayOneShot(mouseHover);
    }

    // Mouse down sound + record which button was pressed
    public void Play_MouseDown()
    {
        if (mouseHover != null)
            audioSource.PlayOneShot(mouseDown);

        PlayButtonSounds.currentButton = thisButton;
    }

    // Mouse up sound (only if released on same button)
    public void Play_MouseUp()
    {
        if (PlayButtonSounds.currentButton == thisButton)
        {
            if (mouseUp != null)
            audioSource.PlayOneShot(mouseUp);

            StartCoroutine(WaitForMouseUpSound());
        }

        currentButton = -1;
    }
    IEnumerator WaitForMouseUpSound()
    {
        // Wait until the AudioSource has finished playing the mouseUp sound
        while (audioSource.isPlaying)
            yield return null;

        // Perform button action based on ID
        if (thisButton == 1)
        {
            // Start Game: load scene 1 (must exist in Build Settings)
            SceneManager.LoadScene(1);
        }
        else if (thisButton == 2)
        {
            // Exit
            Application.Quit();
        }
    }

}

