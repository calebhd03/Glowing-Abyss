using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Cosmetics", menuName = "ScriptableObjects/Cosmetics", order = 1)]
public class Cosmetics : ScriptableObject
{
    public List<Sprite> planktonHats = new List<Sprite>();
    public List<GameObject> planktonTrails = new List<GameObject>();
    //public List<Sprite> planktonWings = new List<Sprite>();
}
