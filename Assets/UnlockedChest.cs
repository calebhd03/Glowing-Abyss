using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockedChest : MonoBehaviour
{

    public UnlockedItem item;
    public int unlockedIndex;
    public Cosmetics cosmetics;
    public enum UnlockedItem
    {
        Hat,
        Trail,
        Wings,
    }
    public void UnlockChest()
    {
        Debug.Log("Unlocked " + item.ToString() + " : " + unlockedIndex);

        if (item == UnlockedItem.Hat)
        {
            string hatUnlocked = "hat" + unlockedIndex.ToString();
            PlayerPrefs.SetInt(hatUnlocked, 1);
        }
        else if (item == UnlockedItem.Trail)
        {
            string trailUnlocked = "trail" + unlockedIndex.ToString();
            PlayerPrefs.SetInt(trailUnlocked, 1);
        }
        else if(item == UnlockedItem.Wings)
        {
            string wingUnlocked = "Wing" + unlockedIndex.ToString();
            PlayerPrefs.SetInt(wingUnlocked, 1);
        }
        else
        {
            Debug.LogError("Unlocked item not selected");
        }
    }
}
