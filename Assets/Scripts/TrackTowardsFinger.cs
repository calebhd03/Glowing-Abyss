using System.Drawing;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class TrackTowardsFinger : MonoBehaviour
{
    public Joystick joystick;
    NavMeshAgent navMeshAgent;
    private Camera cam;
    FocusingTarget focusingTarget;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        cam = Camera.main;
    }

    public void Update()
    {
        //move player
        Vector2 dir = joystick.Direction;
        navMeshAgent.destination = new Vector3(transform.position.x + dir.x, transform.position.y + dir.y, transform.position.z);
    
        //face plankton towards direction
    }

    public void StopMoving()
    {
        navMeshAgent.isStopped = true;
    }
    public void StartMoving()
    {
        navMeshAgent.isStopped = false;
    }
}
