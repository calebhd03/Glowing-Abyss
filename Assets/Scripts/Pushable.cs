using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using System.Collections.Generic;
using System;

public class Pushable : MonoBehaviour
{
    [SerializeField] int requiredPlankton;
    [SerializeField] bool multiplePushable;
    [SerializeField] bool pausePlayerMovement = true;
    [SerializeField] AudioSource pushedSound;

    [Header("Refrences")]
    [SerializeField] Animator animatorSp;
    [SerializeField] Animator animatorLi;
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] Transform spriteT;
    [SerializeField] List<PlanktonTracking> revivedPlanktonList = new List<PlanktonTracking>();
    [SerializeField] UnityEvent AfterPushed;
    [HideInInspector] public GameManager gameManager;

    GameObject player;
    bool canBePushed = true;

    public static event Action interactButtonOn;
    public static event Action interactButtonOff;

    private void Start()
    {
        if (text != null) text.text = requiredPlankton.ToString();

        //disables all connected plankton
        foreach (PlanktonTracking pt in revivedPlanktonList) {
            if (pt != null)
            {
                Debug.Log("disabled " + pt.name); 
                pt.Disabled();
            }
            
        }

    }

    private void OnDisable()
    {
        InteractButton.interactButtonPressed -= StartPushing;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            player = other.gameObject;

            CheckAction();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            interactButtonOff.Invoke();
            InteractButton.interactButtonPressed -= StartPushing;
        }
    }

    private void CheckAction()
    {
        if (!canBePushed)
            return;

        Debug.Log("checking push with " + player.GetComponent<FocusingTarget>().planktonAmount() + " plankton");
        if (player.GetComponent<FocusingTarget>().planktonAmount() >= requiredPlankton)
        {
            interactButtonOn.Invoke();
            InteractButton.interactButtonPressed += StartPushing;
        }
    }

    public void StartPushing()
    {
        Debug.Log("Start Pushing : " + this.gameObject.name);

        canBePushed = false;

        player.GetComponent<FocusingTarget>().targetingPoint = spriteT;
        if (pausePlayerMovement) player.GetComponent<TrackTowardsFinger>().StopMoving();
        animatorSp.SetTrigger("Push"); 
        pushedSound.Play();
        if (animatorLi != null) animatorLi.SetTrigger("Push");

        //revives all connected planktons
        foreach(PlanktonTracking pt in revivedPlanktonList) {
            if (pt != null)
            {
                Debug.Log("Revived " + pt.name); 
                pt.Revived(); 

            }

        }
    }

    public void StopPushing()
    {
        Debug.Log("Stop Pushing : " + this.gameObject.name);

        if (multiplePushable) canBePushed = true;

        player.GetComponent<FocusingTarget>().targetingPoint = player.transform;
        if (pausePlayerMovement) player.GetComponent<TrackTowardsFinger>().StartMoving();

        //Test gameManager win conditions
        if (gameManager != null) gameManager.Pushed(this);
        if (AfterPushed != null) AfterPushed.Invoke();
    }
    public void StopAfterSec(float time)
    {
        StartCoroutine(wait(time));
    }

    IEnumerator wait(float time)
    {
        yield return new WaitForSeconds(time);
        StopPushing();
    }
}