using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [Header("Numbers")]
    public int scaredAmount;
    public float attackDistance;
    public float passiveDistance;
    public float cooldownTime;
    public float attackSpeed;

    [Header("Refrences")]
    public SpriteRenderer[] sprites;
    public AudioClip chaseClip;

    public List<Vector3> patrolPoints = new List<Vector3>();

    [HideInInspector] public GameObject player;

    NavMeshAgent navMeshAgent;
    Animator animator;
    int currentPatrolPoint = 0;
    bool onCooldown = false;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        navMeshAgent.destination = patrolPoints[currentPatrolPoint];
    }

    // Update is called once per frame
    void Update()
    {
        PatrolPath();
        TestAttack();
        LookDirection();
    }

    void LookDirection()
    {
        //left
        if (navMeshAgent.velocity.x < -.05)
        {
            foreach(SpriteRenderer sprite in sprites)
            {
                sprite.flipX = false;
                sprite.transform.localPosition = new Vector3(Mathf.Abs(sprite.transform.localPosition.x), sprite.transform.localPosition.y, sprite.transform.localPosition.z);
            }
        }
        //right
        if (navMeshAgent.velocity.x > .05)
        {
            foreach (SpriteRenderer sprite in sprites)
            {
                sprite.flipX = true;
                sprite.transform.localPosition = new Vector3(-Mathf.Abs(sprite.transform.localPosition.x), sprite.transform.localPosition.y, sprite.transform.localPosition.z);
            }
        }
    }

    public void PatrolPath()
    {
        //attacking player
        if(animator.GetBool("Attack") == true && !onCooldown && NotScared())
        {
            navMeshAgent.destination = player.transform.position;
        }

        //reached current patrol point
        else if(Vector3.Distance(this.transform.position, patrolPoints[currentPatrolPoint]) < .2f || !NotScared())
        {
            //move to next patrol point
            if (currentPatrolPoint == patrolPoints.Count - 1)
                currentPatrolPoint = 0;
            else
                currentPatrolPoint++;

            GoToNextPoint();
        }
    }

    public void GoToNextPoint()
    {
        navMeshAgent.destination = patrolPoints[currentPatrolPoint];
    }

    public void TestAttack()
    {
        float distToPlayer = Vector3.Distance(this.transform.position, player.transform.position);
        if(onCooldown)
        {
        }
        else if(distToPlayer <= attackDistance && NotScared())
        {
            AttackPlayer();
        }
        else if(distToPlayer > passiveDistance || !NotScared())
        {
            StopAttackPlayer();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //eat plankton
        if(collision.CompareTag("Plankton") && animator.GetBool("Attack"))
        {
            EatPlankton(collision);
        }
    }

    public void AttackPlayer()
    {
        animator.SetBool("Attack", true);
    }

    public void StopAttackPlayer()
    {
        animator.SetBool("Attack", false);
        GoToNextPoint();
    }
    public void PlayChaseSound()
    {
        AudioManager.instance.SwapTrack(chaseClip);
    }

    public void StopChaseSound()
    {
        AudioManager.instance.ReturnToDefault();
    }

    public void EatPlankton(Collider2D planktonCol)
    {
        if(!onCooldown)
        {
            Debug.Log("Eat plankton " + planktonCol.name);
            StartCoroutine(cooldown());
            GoToNextPoint();

            PlanktonTracking pt = planktonCol.GetComponent<PlanktonTracking>();
            player.GetComponent<FocusingTarget>().RemovePlanktonFromList(pt);
            pt.Ate();
        }
    }

    bool NotScared()
    {
        return (player.GetComponent<FocusingTarget>().planktonAmount() < scaredAmount);
    }

    IEnumerator cooldown()
    {
        onCooldown = true;
        animator.SetTrigger("Start Cooldown");

        yield return new WaitForSeconds(cooldownTime);

        onCooldown = false;
        animator.SetTrigger("End Cooldown");
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        for(int i = 0; i < patrolPoints.Count-1; i++)
        {
            Gizmos.DrawSphere(patrolPoints[i], 1f);
            Gizmos.DrawLine(patrolPoints[i], patrolPoints[i+1]);
        }

        Gizmos.DrawSphere(patrolPoints[patrolPoints.Count-1], 1f);
        Gizmos.DrawLine(patrolPoints[patrolPoints.Count-1], patrolPoints[0]);
    }

    private void OnDrawGizmosSelected()
    {
        //Draw passive circle
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(this.transform.position, passiveDistance);

        //Draw attack circle
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, attackDistance);
    }
}
