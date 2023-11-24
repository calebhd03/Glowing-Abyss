using System.Drawing;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class TrackTowardsFinger : MonoBehaviour
{
    public Joystick joystick;
    public AudioSource movingSound;
    public bool takingInput = true;
    [SerializeField] private LayerMask layermask;

    NavMeshAgent navMeshAgent;
    private Camera cam;
    bool isMoving = false;

    RaycastHit2D raycast;
    Ray ray;
    Vector2 dir;

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
        dir = joystick.Direction;
        Debug.Log("dir " + dir);

        if (takingInput)
        {
            LayerMask mask = LayerMask.GetMask("Plankton");
            mask = -(mask);
            //Debug.Log(" mask " + mask);

            raycast = Physics2D.Raycast(transform.position, dir, 1f, layermask);

            Debug.Log("ray point: " + raycast.point);
            if(raycast.collider!=null) Debug.Log("ray name: " + raycast.collider.name);

            Ray ray = new Ray(transform.position, dir);

            if(raycast)
            {
                SetDestination(ray.GetPoint(raycast.distance-.1f));
            }
            else
            {
                SetDestination(ray.GetPoint(1f));
            }

        }

        MovingSound();

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(raycast.point, 1f);
        Gizmos.DrawRay(transform.position, dir);
    }

    private void MovingSound()
    {
        if (navMeshAgent.velocity.magnitude > 0)
        {
            if (isMoving == false)
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

    public void SetDestination(Vector3 dest)
    {
        navMeshAgent.destination = dest;
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
