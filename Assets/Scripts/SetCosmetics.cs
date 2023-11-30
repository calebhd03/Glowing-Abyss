using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetCosmetics : MonoBehaviour
{
    public bool lockCosmetics = false;
    public SwitchCosmetics switchCosmetics;
    public List<Button> headList = new List<Button>();
    public List<Button> bodyList = new List<Button>();
    public List<Button> trailList = new List<Button>();


    private void Start()
    {
        Debug.Log("planktonHat = " + PlayerPrefs.GetInt("planktonHat"));
        Debug.Log("planktonTrail = " + PlayerPrefs.GetInt("planktonTrail"));
        Debug.Log("planktonWing = " + PlayerPrefs.GetInt("planktonWing"));

        if (lockCosmetics) LockCosmetics();
    }

    public void LockCosmetics()
    {
        for (int i = 0; i < headList.Count; i++)
        {
            string s = "hat" + i;
            if (PlayerPrefs.GetInt(s) == 0)
                headList[i].interactable = false;
            else
                headList[i].interactable = true;
        }
        for (int i = 0; i < trailList.Count; i++)
        {
            string s = "trail" + i;
            if (PlayerPrefs.GetInt(s) == 0)
                trailList[i].interactable = false;
            else
                trailList[i].interactable = true;
        }
        for (int i = 0; i < bodyList.Count; i++)
        {
            string s = "Wing" + i;
            if (PlayerPrefs.GetInt(s) == 0)
                bodyList[i].interactable = false;
            else
                bodyList[i].interactable = true;
        }
    }

    public void SetPlanktonHat(int hatIndex)
    {
        PlayerPrefs.SetInt("planktonHat", hatIndex);
        PlayerPrefs.Save();
        Debug.Log(PlayerPrefs.GetInt("planktonHat"));
        RefreshPlankton();
    }
    public void SetPlanktonTrail(int trailIndex)
    {
        PlayerPrefs.SetInt("planktonTrail", trailIndex);
        PlayerPrefs.Save();
        Debug.Log(PlayerPrefs.GetInt("planktonTrail"));
        RefreshPlankton();
    }
    public void SetPlanktonWing(int wingIndex)
    {
        PlayerPrefs.SetInt("planktonWing", wingIndex);
        PlayerPrefs.Save();
        Debug.Log(PlayerPrefs.GetInt("planktonWing"));
        RefreshPlankton();
    }

    public void RefreshPlankton()
    {
        if(switchCosmetics!= null)
        {
            switchCosmetics.UpdateSkins();
        }
    }
}
