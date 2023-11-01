using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextScene : MonoBehaviour
{
    public void LoadNextLevel()
    {
        //last level
        if (SceneManager.GetActiveScene().buildIndex >= SceneManager.sceneCount)
            SceneManager.LoadScene(0);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
