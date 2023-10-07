using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class Pushable : MonoBehaviour
{
    [SerializeField] int requiredPlankton;
    [SerializeField] bool multiplePushable;
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] Transform spriteT;
    [SerializeField] UnityEvent AfterPushed;
    [HideInInspector] public GameManager gameManager;

    GameObject player;
    bool canBePushed = true;
    Animator animator;

    private void Start() {
        animator = GetComponent<Animator>();
        if(text!= null ) text.text = requiredPlankton.ToString();
    }

    private void OnTriggerEnter2D(Collider2D other) {

        if(other.CompareTag("Player"))
        {
            player = other.gameObject;
            CheckAction();
        }
    }

    private void CheckAction()
    {
        if(!canBePushed)
            return;

        Debug.Log("checking push with " + player.GetComponent<FocusingTarget>().planktonAmount() + " plankton");
        if(player.GetComponent<FocusingTarget>().planktonAmount() >= requiredPlankton)
        {
            StartPushing();
        }
    }

    public void StartPushing()
    {
        Debug.Log("Start Pushing : " + this.gameObject.name);

        canBePushed = false;
        player.GetComponent<FocusingTarget>().targetingPoint = spriteT;
        animator.SetTrigger("Push");
    }

    public void StopPushing()
    {
        Debug.Log("Stop Pushing : " + this.gameObject.name);

        if(multiplePushable) canBePushed = true;

        player.GetComponent<FocusingTarget>().targetingPoint = player.transform;

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
