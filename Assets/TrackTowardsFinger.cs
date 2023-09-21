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
        Debug.Log("Value  = " + value);
        Debug.Log("value.Get<Vector2>()  = " + value.Get<Vector2>()); 
        Vector2 pos = value.Get<Vector2>();
        Vector3 dest = cam.ScreenToWorldPoint(new Vector3(pos.x, pos.y, cam.nearClipPlane));
        Debug.Log("dest  = " + dest);
        navMeshAgent.destination = dest;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
