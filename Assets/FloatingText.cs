using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    public float minDistance;

    public TextMeshProUGUI text;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        text.alpha = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(player.transform.position, transform.position);

        float a = minDistance / dist;
        text.color = new Color(text.color.r, text.color.g, text.color.b, a*a);
        
    }
}
