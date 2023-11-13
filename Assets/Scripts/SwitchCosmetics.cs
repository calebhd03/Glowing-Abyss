using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCosmetics : MonoBehaviour
{
    [SerializeField] Cosmetics cosmetics;
    [SerializeField] PlanktonManager planktonManager;


    // Start is called before the first frame update
    void Start()
    {
        foreach(PlanktonTracking pt in planktonManager.planktons)
        {
            pt.planktonHat = cosmetics.planktonHats[PlayerPrefs.GetInt("planktonHat")];
            pt.planktonTrail = cosmetics.planktonHats[PlayerPrefs.GetInt("planktonTrail")];
            pt.planktonWing.SetInteger("planktonWing", PlayerPrefs.GetInt("planktonWing"));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
