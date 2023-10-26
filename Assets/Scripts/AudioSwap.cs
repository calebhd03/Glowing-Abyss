using UnityEngine;

public class AudioSwap : MonoBehaviour
{
    public AudioClip newClip;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AudioManager.instance.SwapTrack(newClip);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AudioManager.instance.ReturnToDefault();
        }
    }
}