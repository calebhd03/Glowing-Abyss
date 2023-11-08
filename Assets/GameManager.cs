using Cinemachine;
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
    [SerializeField] GameObject allDeadUI;
    public int requiredPlankton = 0;
    [SerializeField] GameObject notEnoughPlanktonUI;
    [SerializeField] PlanktonManager planktonManager;
    [SerializeField] CinemachineVirtualCamera vcam1;
    [SerializeField] CinemachineVirtualCamera vcam2;
    [SerializeField] Animator stateCinemachineCamera;
    public UnityEvent OnLooseLevel;

    [SerializeField] List<Pushable> allPlants = new List<Pushable>();
    [SerializeField] List<Pushable> illuminatedPlants = new List<Pushable>();

    public void Start()
    {
        Pushable[] illumList = IllumParentObj.GetComponentsInChildren<Pushable>();
        allPlants = illumList.ToList<Pushable>();
        Debug.Log(allPlants.Count);

        Time.timeScale = 1;

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

        allDeadUI.SetActive(true);
        OnLooseLevel.Invoke();
    }

    public void TestNotEnough()
    {
        Debug.Log("Test enough");
        if(planktonManager.planktons.Count < requiredPlankton)
        {
            Debug.LogWarning("Level Lost!");

            notEnoughPlanktonUI.SetActive(true);
            OnLooseLevel.Invoke();
        }
    }

    public void WinLevel()
    {
        Debug.LogWarning("Level Won!");

        if (levelRequirements.levelNumber >= PlayerPrefs.GetInt("levelReached"))
            PlayerPrefs.SetInt("levelReached", levelRequirements.levelNumber + 1);

        SwitchToEndOfLevelCamera();
    }

    public void ShowWinUI()
    {
        winningUI.SetActive(true);
    }

    public void SwitchToEndOfLevelCamera()
    {
        stateCinemachineCamera.Play("End of level");

        int p = vcam2.Priority;
        vcam1.Priority = vcam2.Priority;
        vcam2.Priority = p;
    }
}