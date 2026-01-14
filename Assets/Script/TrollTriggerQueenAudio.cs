using UnityEngine;

public class TrollTriggerQueenAudio : MonoBehaviour
{
    [Tooltip("Drag the Queen GameObject here")]
    public GameObject queen;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && queen != null)
        {
            AudioSource queenAudio = queen.GetComponent<AudioSource>();
            if (queenAudio != null && !queenAudio.isPlaying)
            {
                queenAudio.Play();
            }
        }
    }
}
