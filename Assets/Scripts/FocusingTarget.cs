using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
using System;
using TMPro;

public class FocusingTarget : MonoBehaviour
{
    [SerializeField] float pullingStrength = 1.0f;
    [SerializeField] TextMeshProUGUI counterText;
    [SerializeField] List<PlanktonTracking> planktonTrackingsList= new List<PlanktonTracking>();
    [HideInInspector] public GameManager gameManager;
    public UnityEvent m_MyEvent;

    public Transform targetingPoint;
    CircleCollider2D playerCol;
    // Start is called before the first frame update
    void Start()
    {
        playerCol = GetComponent<CircleCollider2D>();
        targetingPoint = transform;
        //Find plankton already sitting in circle
        Collider2D[] ret = Physics2D.OverlapCircleAll(new Vector2(transform.position.x, transform.position.y), playerCol.radius);
        foreach(Collider2D c in ret)
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
        foreach(PlanktonTracking p in planktonTrackingsList)
        {
            p.MoveTowards(targetingPoint.position, pullingStrength);
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
        Debug.Log("Added : " + pt.name + " to list");
        planktonTrackingsList.Add(pt);

        if(counterText != null) counterText.text = planktonAmount().ToString();
        if(gameManager != null) gameManager.TestWin();
    }

    public int planktonAmount()
    {
        return planktonTrackingsList.Count;
    }
}
