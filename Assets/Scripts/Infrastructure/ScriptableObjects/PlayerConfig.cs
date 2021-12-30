using UnityEngine;

namespace Assets.Scripts.Infrastructure.ScriptableObjects
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "ScriptableObjects/PlayerConfig")]
    public class PlayerConfig : ScriptableObject
    {
        [Tooltip("Максимальное количество здоровья.")]
        public float MaxHp = 100f;
    }
}
