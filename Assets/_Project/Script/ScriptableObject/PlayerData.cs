using UnityEngine;

namespace BelumProduktif.ScriptableObject
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "Scriptable Object/Entities/New Player Data", order = 0)]
    public class PlayerData : UnityEngine.ScriptableObject
    {
        [field: SerializeField] public string PlayerName {get; private set;}
        [field: SerializeField] public float PlayerJumpForce {get; private set;}
        [field: SerializeField] public float PlayerMaxJumpTime {get; private set;}
    }
}