using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{

    Animator animator;

    int levelToLoad = 0;

    public void Start()
    {
        animator = GetComponent<Animator>();
    }
    
    public void FadeToLevel(int sceneIndex)
    {
        animator.SetTrigger("FadeOut");
        levelToLoad = sceneIndex;
    }

    public void FadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
