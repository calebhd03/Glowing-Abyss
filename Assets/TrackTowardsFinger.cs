using System.Drawing;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class TrackTowardsFinger : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    private Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent= GetComponent<NavMeshAgent>();
        cam = Camera.main;
    }

    public void OnTouchPosition(InputValue value)
    {
        Vector2 pos = value.Get<Vector2>();
        Vector3 dest = cam.ScreenToWorldPoint(new Vector3(pos.x, pos.y, cam.nearClipPlane));
        
        navMeshAgent.destination = dest;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
