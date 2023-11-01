using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class PlanktonManager : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI counterText;

    List<PlanktonTracking> planktons = new List<PlanktonTracking>();

    // Start is called before the first frame update
    void Start()
    {
        planktons = GetComponentsInChildren<PlanktonTracking>().ToList<PlanktonTracking>();
        UpdatePlanktonMaxCounter();
    }

    public void remove(PlanktonTracking pt)
    {
        planktons.Remove(pt);
        UpdatePlanktonMaxCounter();
    }

    public void UpdatePlanktonMaxCounter()
    {
        counterText.text = planktons.Count.ToString();
    }
}
