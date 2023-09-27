using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //TODO: Create an event that checks how many plankton are on player
    //TODO: Scene Fader

    public LevelRequirements levelRequirements;
    public FocusingTarget playerTracking;

    public void TestWin()
    {
        if(playerTracking.planktonAmount() >= levelRequirements.requiredPlankton)
            WinLevel();
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
