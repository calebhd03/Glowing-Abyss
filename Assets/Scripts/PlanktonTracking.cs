using UnityEngine;

public class PlanktonTracking : MonoBehaviour
{
    public GameObject spriteObj;

    Animator animator;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        
        //spriteObj.transform.rotation = Quaternion.Euler(90, 0, -90);
    }

    public void MoveTowards(Vector3 pos, float speed, Vector3 lookDirection)
    {
        transform.position = Vector3.MoveTowards(transform.position, pos, speed);

        transform.right = lookDirection;
    }

    public void Ate()
    {
        Destroy(gameObject);
    }
}
