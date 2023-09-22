using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    //public Fader sceneFader;

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
