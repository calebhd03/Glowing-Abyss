using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Geyser : MonoBehaviour
{
    [Header("Numbers")]
    public float sprayTime;
    public float cooldownTime;
    public float audioFadeTime;

    [Header("Refrences")]
    public ParticleSystem bubbles;

    AudioSource geyserSound;

    private void Start()
    {
        geyserSound = GetComponent<AudioSource>();
        StartBubbles();
    }

    void StartBubbles()
    {
        StartCoroutine(StartBubbleSound());
        bubbles.Play();
        StartCoroutine(BubblesCooldown());
    }

    void StopBubbles()
    {
        StartCoroutine(StopBubbleSound());
        bubbles.Stop(true, ParticleSystemStopBehavior.StopEmitting);
    }

    private IEnumerator StartBubbleSound()
    {
        float timeElapsed = 0f;
        while (timeElapsed < audioFadeTime)
        {
            geyserSound.volume = Mathf.Lerp(0, 1, timeElapsed / audioFadeTime);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
    }
    private IEnumerator StopBubbleSound()
    {
        float timeElapsed = 0f;
        while (timeElapsed < audioFadeTime)
        {
            geyserSound.volume = Mathf.Lerp(1, 0, timeElapsed / audioFadeTime);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
    }

    private IEnumerator BubblesCooldown()
    {
        yield return new WaitForSeconds(sprayTime);
        StopBubbles();
        yield return new WaitForSeconds(cooldownTime);
        StartBubbles();
    }
}
