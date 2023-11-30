using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.AI;

public class FocusingTarget : MonoBehaviour
{
    public int requiredPlanktonToWin = 0;
    [SerializeField] float pullingStrength = 1.0f;
    public float deathCooldownTimer;
    public AudioSource collectSound;
    public AudioSource deadSound;

    [Header("Refrences")]
    public PlanktonManager planktonManager; 
    [SerializeField] TextMeshProUGUI counterText;
    [SerializeField] List<PlanktonTracking> planktonTrackingsList = new List<PlanktonTracking>();
    [HideInInspector] public GameManager gameManager;
    public UnityEvent m_MyEvent;

    public Transform targetingPoint;
    [HideInInspector] public bool canDie = true;
    CircleCollider2D playerCol;
    // Start is called before the first frame update
    void Start()
    {
        playerCol = GetComponent<CircleCollider2D>();
        targetingPoint = transform;
        //Find plankton already sitting in circle
        Collider2D[] ret = Physics2D.OverlapCircleAll(new Vector2(transform.position.x, transform.position.y), playerCol.radius);
        foreach (Collider2D c in ret)
        {
            PlanktonTracking pt = c.gameObject.GetComponent<PlanktonTracking>();
            if (pt != null)
            {
                AddPlanktonToList(pt);
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        for (int i=0; i<planktonTrackingsList.Count; i++)
        {
            planktonTrackingsList[i].MoveTowards(targetingPoint.position, pullingStrength, transform.forward, GetComponent<NavMeshAgent>().velocity);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        PlanktonTracking pt = collision.gameObject.GetComponent<PlanktonTracking>();

        if (pt == null)
            return;
        if (planktonTrackingsList.Contains(pt))
            return;

        AddPlanktonToList(pt);
    }

    public void AddPlanktonToList(PlanktonTracking pt)
    {
        //plankton is disabled
        if(pt.disabled) return;

        Debug.Log("Added : " + pt.name + " to list");
        planktonTrackingsList.Add(pt);

        collectSound.Play();

        if (counterText != null) counterText.text = planktonAmount().ToString();
        if (gameManager != null) gameManager.TestWin();
    }

    public bool CanPlanktonDie()
    {
        if(!canDie)
            return false;

        StartCoroutine(DeathCooldown());
        return true;
    }

    IEnumerator DeathCooldown()
    {
        canDie = false;
        yield return new WaitForSeconds(deathCooldownTimer);
        canDie = true;
    }

    public void RemovePlanktonFromList(PlanktonTracking pt)
    {
        Debug.Log("Removed : " + pt.name + " from list");
        planktonTrackingsList.Remove(pt);

        deadSound.Play();

        if (counterText != null) counterText.text = planktonAmount().ToString();
        if (gameManager != null) gameManager.TestWin();

            Debug.Log("plankton amount " + planktonAmount());

        if (planktonAmount() <= 0 || planktonManager.planktons.Count < requiredPlanktonToWin)
        {
            gameManager.LooseLevel();
        }
    }

    public int planktonAmount()
    {
        return planktonTrackingsList.Count;
    }
}