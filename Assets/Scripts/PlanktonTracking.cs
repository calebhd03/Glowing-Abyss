using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class PlanktonTracking : MonoBehaviour
{

    public float speed;
    public Vector3 direction;
    public GameObject spriteObj;

    Animator animator;
    NavMeshAgent navMeshAgent;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        
        spriteObj.transform.rotation = Quaternion.Euler(90, 0, 0);
    }

    public void MoveTowards(Vector3 pos, float speed)
    {
        //transform.position = Vector3.MoveTowards(transform.position, pos, speed);

        navMeshAgent.destination = pos;

        //spriteObj.transform.LookAt(pos, Vector3.up);
        //transform.right = pos- transform.position;
    }

    public void Ate()
    {
        Destroy(gameObject);
    }
}
