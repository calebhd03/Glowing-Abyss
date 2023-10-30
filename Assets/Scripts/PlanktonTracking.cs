using System.Collections;
using UnityEngine;

public class PlanktonTracking : MonoBehaviour
{
    public float timeBeforeDestroy;
    public SpriteRenderer sprite;
    public bool click = false;
    public AudioSource deadPlanktonSound;

    bool dead = false;
    Animator animator;
    float swimAnimSpeed;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();

        swimAnimSpeed = Random.Range(.8f, 1.2f);

        //spriteObj.transform.rotation = Quaternion.Euler(90, 0, -90);

    }

    private void OnParticleCollision(GameObject other)
    {
        //plankton collides with geyser Bubbles
        if(other.CompareTag("Geyser"))
        {
            Ate();
        }
    }

    public void MoveTowards(Vector3 pos, float speed, Vector3 lookDirection, Vector3 playerSpeed)
    {
        if(dead)
        { return; }

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
        dead = true;
        sprite.enabled = false;
        deadPlanktonSound.Play();
        animator.SetTrigger("Died");
        StartCoroutine(destoryAfter());
    }

    IEnumerator destoryAfter()
    {
        yield return new WaitForSeconds(timeBeforeDestroy);
        Destroy(gameObject);
    }
}
