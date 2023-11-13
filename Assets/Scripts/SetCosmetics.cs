using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCosmetics : MonoBehaviour
{
    private void Start()
    {
        Debug.Log("planktonHat = " + PlayerPrefs.GetInt("planktonHat"));
        Debug.Log("planktonTrail = " + PlayerPrefs.GetInt("planktonTrail"));
        Debug.Log("planktonHat = " + PlayerPrefs.GetInt("planktonHat"));
    }

    public void SetPlanktonHat(int hatIndex)
    {
        PlayerPrefs.SetInt("planktonHat", hatIndex);
        Debug.Log(PlayerPrefs.GetInt("planktonHat"));
    }
    public void SetPlanktonTrail(int hatIndex)
    {
        PlayerPrefs.SetInt("planktonTrail", hatIndex);
        Debug.Log(PlayerPrefs.GetInt("planktonTrail"));
    }
    public void SetPlanktonWing(int hatIndex)
    {
        PlayerPrefs.SetInt("planktonWing", hatIndex);
        Debug.Log(PlayerPrefs.GetInt("planktonWing"));
    }
}
