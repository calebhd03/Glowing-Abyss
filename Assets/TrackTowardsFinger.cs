using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class TrackTowardsFinger : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent= GetComponent<NavMeshAgent>();
    }

    public void OnTouchPosition(InputValue value)
    {
        Debug.Log("Value  = " + value);
        Debug.Log("value.Get<Vector2>()  = " + value.Get<Vector2>());
        navMeshAgent.destination = value.Get<Vector2>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
