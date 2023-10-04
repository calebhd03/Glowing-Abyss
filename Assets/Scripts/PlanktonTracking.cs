using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlanktonTracking : MonoBehaviour
{
    public void MoveTowards(Vector3 pos, float speed)
    {
        transform.position = Vector3.MoveTowards(transform.position, pos, speed);
    }
}
