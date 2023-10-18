using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingTextManager : MonoBehaviour
{
    public GameObject player;

    void Start()
    {
        FloatingText[] enemies = GetComponentsInChildren<FloatingText>();
        foreach (FloatingText f in enemies)
        {
            f.player = this.player;
        }
    }
}
