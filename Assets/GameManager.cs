using System;
using System.Collections.Generic;
using System.Linq;
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

    [SerializeField] GameObject winningUI;
    [SerializeField] List<Pushable> allPlants = new List<Pushable>();
    [SerializeField] List<Pushable> illuminatedPlants = new List<Pushable>();

    public void Start()
    {
        Pushable[] illumList = IllumParentObj.GetComponentsInChildren<Pushable>();
        allPlants = illumList.ToList<Pushable>();
        Debug.Log(allPlants.Count);

        foreach (Pushable i in allPlants)
        {
            //set gameManager in illum
            i.gameManager = this;

        }
        //set player gamaeManager
        playerTracking.gameManager = this;
    }

    public void TestWin()
    {
        WinCondition cond = levelRequirements.winCondition;

        if (cond == WinCondition.FinalPlantLit)
        {
            //Done through a Unity Event on the final plant
        }
        else if (cond == WinCondition.RequiredPlanktonNumber)
        {
            if (playerTracking.planktonAmount() >= levelRequirements.requiredPlankton)
                WinLevel();
        }
        else if (cond == WinCondition.AllPlantsLit)
        {
            for (int i = 0; i < illuminatedPlants.Count; i++)
            {
                Debug.Log(i + " is " + illuminatedPlants);
            }

            if (illuminatedPlants.Count >= allPlants.Count)
                WinLevel();
        }
    }

    public void Pushed(Pushable pushed)
    {
        if (!illuminatedPlants.Contains(pushed))
            illuminatedPlants.Add(pushed);

        TestWin();
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

        if (levelRequirements.levelNumber >= PlayerPrefs.GetInt("levelReached"))
            PlayerPrefs.SetInt("levelReached", levelRequirements.levelNumber + 1);

        winningUI.SetActive(true);

        //TODO: Scene Fader
    }
}