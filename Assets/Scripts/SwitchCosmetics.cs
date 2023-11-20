using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SwitchCosmetics : MonoBehaviour
{
    [SerializeField] Cosmetics cosmetics;
    [SerializeField] PlanktonManager planktonManager;


    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("planktonTrail", 0);
        PlayerPrefs.SetInt("planktonWing", 0);
        //UpdateSkins();
        //StartCoroutine(swap());
    }

    IEnumerator swap()
    {
        yield return new WaitForSeconds(3);
        UpdateSkins();
        StartCoroutine(swap());
    }
    public void UpdateSkins()
    {
        Debug.Log("Updating skins");
        foreach (PlanktonTracking pt in planktonManager.planktons)
        {
            if (pt == null) break;
            //PlayerPrefs.GetInt("planktonHat");
            //pt.planktonHat = cosmetics.planktonHats[PlayerPrefs.GetInt("planktonHat")];

            Destroy(pt.planktonTrail);
            Quaternion QTmp = pt.planktonTrail.transform.rotation;
            GameObject temp = Instantiate(cosmetics.planktonTrails[PlayerPrefs.GetInt("planktonTrail")], pt.transform.position, QTmp, pt.transform);
            temp.name = "bubbleTrail";
            pt.planktonTrail = temp;

            pt.planktonWing.SetInteger("planktonWing", PlayerPrefs.GetInt("planktonWing"));
        }
    }
}
