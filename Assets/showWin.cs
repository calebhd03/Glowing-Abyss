using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showWin : MonoBehaviour
{
    public GameManager gameManager;
    public float timeBetweenBlend;

    public void Show()
    {
        StartCoroutine(ShowUIAfter());
    }
    IEnumerator ShowUIAfter()
    {
        yield return new WaitForSeconds(timeBetweenBlend);

        Debug.Log("Swapping Cameras");
        gameManager.ShowWinUI();
    }
}
