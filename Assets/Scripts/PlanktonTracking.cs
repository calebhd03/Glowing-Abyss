using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlanktonTracking : MonoBehaviour
{
    public void MoveTowards(Vector3 pos, float speed)
    {
        animator = GetComponentInChildren<Animator>();
        
        swimAnimSpeed = Random.Range(.8f, 1.2f);

        //spriteObj.transform.rotation = Quaternion.Euler(90, 0, -90);

    }

    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("OTher thing Particl + " + other);
    }

    public void MoveTowards(Vector3 pos, float speed, Vector3 lookDirection, Vector3 playerSpeed)
    {
        Vector3 oldPos = transform.position;

        transform.position = Vector3.MoveTowards(transform.position, pos, speed);
    }

    public void Ate()
    {
        Destroy(gameObject);
    }
}
