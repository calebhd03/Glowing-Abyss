using UnityEngine;

public class PlanktonTracking : MonoBehaviour
{
    public GameObject spriteObj;
    public bool click=false;
    Animator animator;
    float swimAnimSpeed;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        
        swimAnimSpeed = Random.Range(.8f, 1.2f);

        //spriteObj.transform.rotation = Quaternion.Euler(90, 0, -90);

    }

    public void MoveTowards(Vector3 pos, float speed, Vector3 lookDirection, Vector3 playerSpeed)
    {
        Vector3 oldPos = transform.position;

        transform.position = Vector3.MoveTowards(transform.position, pos, speed);

        if (playerSpeed == Vector3.zero)
        {
            animator.SetBool("Swimming", false);
            animator.speed = 1;
        }
        else
        {
            animator.SetBool("Swimming", true);
            animator.speed = swimAnimSpeed;
        }

        transform.right = lookDirection;
    }

    public void Ate()
    {
        Destroy(gameObject);
    }
}
