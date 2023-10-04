using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //TODO: Create an event that checks how many plankton are on player
    //TODO: Scene Fader

    public LevelRequirements levelRequirements;
    public FocusingTarget playerTracking;
    public GameObject IllumParentObj;

    List<illum> illums = new List<illum>();

    public void Start()
    {
        Pushable[] illumList = IllumParentObj.GetComponentsInChildren<Pushable>();
        foreach (Pushable i in illumList)
        {
            illum tmp = new illum();
            tmp.illumObj = i;
            tmp.lit = false;
            illums.Add(tmp);
        }
    }
    struct illum
    {
        public Pushable illumObj;
        public bool lit;
    };

    public void TestWin()
    {
        WinCondition cond =levelRequirements.winCondition;

        if (cond == WinCondition.FinalPlantLit)
        {

        }
        else if (cond == WinCondition.RequiredPlanktonNumber)
        {
            if (playerTracking.planktonAmount() >= levelRequirements.requiredPlankton)
                WinLevel();
        }
        else if (cond == WinCondition.RequiredPlanktonNumber)
        {
             
        }
    }

    public void Pushed(GameObject pushedOBJ)
    {
        illums.IndexOf()
        if()
    }

    public void LooseLevel()
    {
        Debug.LogWarning("Level Lost!");

        //TODO: Scene Fader
        SceneManager.LoadScene(0);
    }
    public void WinLevel()
    {
        Debug.LogWarning("Level Won!");

        if(levelRequirements.levelNumber >= PlayerPrefs.GetInt("levelReached"))
            PlayerPrefs.SetInt("levelReached", levelRequirements.levelNumber+1);

        //TODO: Scene Fader
        SceneManager.LoadScene(0);
    }
}
