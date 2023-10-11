using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{

    public List<Vector3> patrolPoints = new List<Vector3>();

    NavMeshAgent navMeshAgent;
    int currentPatrolPoint = 0;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        PatrolPath();
    }

    private void PatrolPath()
    {
        //reached current patrol point
        if(Vector3.Distance(this.transform.position, patrolPoints[currentPatrolPoint]) < .2f)
        {
            //move to next patrol point
            if (currentPatrolPoint == patrolPoints.Count - 1)
                currentPatrolPoint = 0;
            else
                currentPatrolPoint++;


        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        for(int i = 0; i < patrolPoints.Count-1; i++)
        {
            Gizmos.DrawSphere(patrolPoints[i], 2f);
            Gizmos.DrawLine(patrolPoints[i], patrolPoints[i+1]);
        }

        Gizmos.DrawSphere(patrolPoints[patrolPoints.Count-1], 2f);
        Gizmos.DrawLine(patrolPoints[patrolPoints.Count-1], patrolPoints[0]);
    }
}
