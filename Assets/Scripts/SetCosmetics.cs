using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCosmetics : MonoBehaviour
{
    private void Start()
    {
        Debug.Log("planktonHat = " + PlayerPrefs.GetInt("planktonHat"));
        Debug.Log("planktonTrail = " + PlayerPrefs.GetInt("planktonTrail"));
        Debug.Log("planktonWing = " + PlayerPrefs.GetInt("planktonWing"));
    }

    public void SetPlanktonHat(int hatIndex)
    {
        PlayerPrefs.SetInt("planktonHat", hatIndex);
        PlayerPrefs.Save();
        Debug.Log(PlayerPrefs.GetInt("planktonHat"));
    }
    public void SetPlanktonTrail(int trailIndex)
    {
        PlayerPrefs.SetInt("planktonTrail", trailIndex);
        PlayerPrefs.Save();
        Debug.Log(PlayerPrefs.GetInt("planktonTrail"));
    }
    public void SetPlanktonWing(int wingIndex)
    {
        PlayerPrefs.SetInt("planktonWing", wingIndex);
        PlayerPrefs.Save();
        Debug.Log(PlayerPrefs.GetInt("planktonWing"));
    }
}
