using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class PlanktonManager : MonoBehaviour
{
    public bool updateMaxCount = true;
    [SerializeField] TextMeshProUGUI counterText;
    [SerializeField] FocusingTarget player;

    List<PlanktonTracking> planktons = new List<PlanktonTracking>();

    // Start is called before the first frame update
    void Start()
    {
        planktons = GetComponentsInChildren<PlanktonTracking>().ToList<PlanktonTracking>();
        UpdatePlanktonMaxCounter();

        foreach(PlanktonTracking pt in planktons)
        {
            pt.player= this.player;
        }
    }

    public void remove(PlanktonTracking pt)
    {
        planktons.Remove(pt);
        if (updateMaxCount)
            UpdatePlanktonMaxCounter();
    }

    public void UpdatePlanktonMaxCounter()
    {
        counterText.text = planktons.Count.ToString();
    }
}
