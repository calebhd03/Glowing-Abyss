using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //TODO: Create an event that checks how many plankton are on player
    //TODO: Scene Fader
    public void WinLevel()
    {
        Debug.Log("Level Won!");
        PlayerPrefs.SetInt("levelReached", PlayerPrefs.GetInt("levelReached")+1);
    }
}
