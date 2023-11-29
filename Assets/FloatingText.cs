using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    public float maxDistance = 10f; // The maximum distance where the text should be fully visible
    public float minDistance = 2f; // The minimum distance where the text should start fading out
    public float fadeSpeed = 1f; // The speed at which the alpha changes

    public TextMeshProUGUI text;
    public GameObject player;


    private float initialAlpha;
    // Start is called before the first frame update
    void Start()
    {
        initialAlpha = text.alpha;
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(player.transform.position, transform.position);
        float alpha = Mathf.Lerp(initialAlpha, 0, Mathf.InverseLerp(minDistance, maxDistance, dist));

        text.color = new Color(text.color.r, text.color.g, text.color.b, alpha);
        
    }
}
