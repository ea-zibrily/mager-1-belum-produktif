using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Scriptable Object/Entities/New Player Data", order = 0)]
public class PlayerData : ScriptableObject
{
    [field: SerializeField] public string PlayerName {get; private set;}
    [field: SerializeField] public float PlayerJumpForce {get; private set;}
    [field: SerializeField] public float PlayerMaxJumpTime {get; private set;}
}