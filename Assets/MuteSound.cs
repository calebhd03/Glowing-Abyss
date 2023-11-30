using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteSound : MonoBehaviour
{
    bool toogleSoundMuted = false;

    public void ToggleMuteSounds()
    {
        if (toogleSoundMuted)
            AudioListener.volume = 1f;
        else
            AudioListener.volume = 0;

        toogleSoundMuted = !toogleSoundMuted;
    }
}
