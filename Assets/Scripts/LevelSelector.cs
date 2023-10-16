using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    //public Fader sceneFader;

    public bool lockLevels = false;

    public GameObject Grid;

    public Button[] levelButtons;

    private void Start()
    {
        //disabled locked levels
        if(lockLevels)
            DisableLevels();
    }

    //opens scene of level button
    public void Select(string levelToLoad)
    {
        if (levelToLoad == null)
        {
            Debug.LogError("Level loading is null");
            return;
        }

        //sceneFader.FadeTo(levelToLoad);

        SceneManager.LoadScene(levelToLoad);
    }

    public void DisableLevels()
    {
        int LevelReached = PlayerPrefs.GetInt("levelReached", 1);
        Debug.Log("Level reached : " + LevelReached);
        for (int i = LevelReached; i < levelButtons.Length; i++)
        {
            levelButtons[i].interactable = false;
        }
    }
}
