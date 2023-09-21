using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlanktonTracking : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveTowards(Vector3 pos, float speed)
    {
        transform.position = Vector3.MoveTowards(transform.position, pos, speed);
    }
}
