using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Geyser : MonoBehaviour
{
    [Header("Numbers")]
    public float sprayTime;
    public float cooldownTime;

    [Header("Refrences")]
    public ParticleSystem bubbles;

    private void Start()
    {
        StartBubbles();
    }

    void StartBubbles()
    {
        bubbles.Play();
        StartCoroutine(BubblesCooldown());
    }

    private IEnumerator BubblesCooldown()
    {
        Debug.Log("Start");
        yield return new WaitForSeconds(sprayTime);
        Debug.Log("Pause");
        bubbles.Stop(true, ParticleSystemStopBehavior.StopEmitting);
        yield return new WaitForSeconds(cooldownTime);
        StartBubbles();
    }
}
