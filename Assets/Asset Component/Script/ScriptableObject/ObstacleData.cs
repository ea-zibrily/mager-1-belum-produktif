using UnityEngine;

[CreateAssetMenu(fileName = "ObstacleData", menuName = "Scriptable Object/Entities/New Obstacle Data", order = 0)]
public class ObstacleData : ScriptableObject
{
    [field: SerializeField] public string ObstacleName {get; private set;}

}