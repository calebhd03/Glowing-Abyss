using System.Drawing;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class TrackTowardsFinger : MonoBehaviour
{
    public Joystick joystick;
    public AudioSource movingSound;

    NavMeshAgent navMeshAgent;
    private Camera cam;
    bool isMoving = false;
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        cam = Camera.main;
    }

    public void OnTouchPosition(InputValue value)
    {
        //Vector2 pos = value.Get<Vector2>();
        //Vector3 dest = cam.ScreenToWorldPoint(new Vector3(pos.x, pos.y, cam.nearClipPlane));

        //navMeshAgent.destination = dest;
    }

    public void Update()
    {
        Vector2 dir = joystick.Direction;
        navMeshAgent.destination = new Vector3(transform.position.x + dir.x, transform.position.y + dir.y, transform.position.z);

        if(navMeshAgent.velocity.magnitude > 0)
        {
            if(isMoving == false)
            {
                movingSound.Play();
            }
            isMoving = true;
        }
        else
        {
            if (isMoving)
            {
                movingSound.Stop();
            }
            isMoving = false;
        }

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
