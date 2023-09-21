using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FocusingTarget : MonoBehaviour
{
    [SerializeField] float pullingStrength = 1.0f;
    List<PlanktonTracking> planktonTrackingsList= new List<PlanktonTracking>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach(PlanktonTracking p in planktonTrackingsList)
        {
            p.MoveTowards(transform.position, pullingStrength);
        }
    }
}
