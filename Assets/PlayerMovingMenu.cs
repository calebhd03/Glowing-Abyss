using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovingMenu : MonoBehaviour
{
    public NavMeshAgent player;
    public List<Vector3> waypoints;
    int currentWaypoint =0;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        player.SetDestination(waypoints[currentWaypoint]);
    }

    private void Update()
    {
        if(player.remainingDistance <= 1f)
        {
            currentWaypoint++;
            if(currentWaypoint >= waypoints.Count) currentWaypoint = 0;
            player.SetDestination(waypoints[currentWaypoint]);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        for (int i = 0; i < waypoints.Count - 1; i++)
        {
            Gizmos.DrawSphere(waypoints[i], 1f);
            Gizmos.DrawLine(waypoints[i], waypoints[i + 1]);
        }

        Gizmos.DrawSphere(waypoints[waypoints.Count - 1], 1f);
        Gizmos.DrawLine(waypoints[waypoints.Count - 1], waypoints[0]);
    }
}
