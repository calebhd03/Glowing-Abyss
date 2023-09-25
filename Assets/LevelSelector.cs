using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    //public Fader sceneFader;

    public GameObject Grid;
    public GameObject levelPrefab;
    public string[] levelNames;
    public Button[] levelButtons;

    private void Start()
    {
        //disabled locked levels
        int LevelReached = PlayerPrefs.GetInt("levelReached", 1);
        for (int i = LevelReached; i < levelButtons.Length; i++)
        {
            levelButtons[i].interactable = false;
        }
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
}
