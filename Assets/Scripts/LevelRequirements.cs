using UnityEngine;
[CreateAssetMenu(fileName = "Level Requirements", menuName = "ScriptableObjects/LevelRequirements", order = 1)]
public class LevelRequirements : ScriptableObject
{
    public int levelNumber;
    public WinCondition winCondition = new WinCondition();
    public int requiredPlankton;

}
public enum WinCondition
{
    FinalPlantLit,
    AllPlantsLit,
    RequiredPlanktonNumber,
}
