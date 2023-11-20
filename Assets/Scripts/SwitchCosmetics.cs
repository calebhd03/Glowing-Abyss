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
        //PlayerPrefs.SetInt("planktonTrail", 0);
        //PlayerPrefs.SetInt("planktonWing", 0);
        //PlayerPrefs.SetInt("planktonHat", 0);
        UpdateSkins();
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
            Debug.Log("updating skin of " + pt.name);
            PlayerPrefs.GetInt("planktonHat");
            pt.planktonHat.sprite = cosmetics.planktonHats[PlayerPrefs.GetInt("planktonHat")];

            //sets the planktons bubble trail
            Transform QTmp = pt.planktonTrail.transform;
            Destroy(pt.planktonTrail);
            GameObject temp = Instantiate(cosmetics.planktonTrails[PlayerPrefs.GetInt("planktonTrail")], QTmp.position, QTmp.rotation, pt.transform);
            temp.name = "bubbleTrail";
            pt.planktonTrail = temp;
            pt.planktonTrail.GetComponent<ParticleSystem>().Play();

            //sets the planktons wings
            pt.planktonWing.SetInteger("planktonWing", PlayerPrefs.GetInt("planktonWing"));
        }
    }
}
