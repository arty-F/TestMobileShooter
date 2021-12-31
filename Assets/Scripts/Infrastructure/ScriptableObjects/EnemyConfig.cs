using UnityEngine;

namespace Assets.Scripts.Infrastructure.ScriptableObjects
{
    [CreateAssetMenu(fileName = "EnemyConfig", menuName = "ScriptableObjects/EnemyConfig")]
    public class EnemyConfig : ScriptableObject
    {
        public GameObject Prefab;

        [Tooltip("Базовое количество здоровья врага.")]
        public float MaxHp = 2f;

        [Header("Attack"), Tooltip("Время между атаками в секундах.")]
        public float AttackBetweenTime = 1f;

        [Tooltip("Урон, наносимый каждой атакой.")]
        public float AttackDamage = 5f;

        [Header("NavMesh"), Tooltip("Время через которое обновляется destination у navMeshAgent, в секундах.")]
        public float NavMeshDestRefreshTime = 0.5f;

        [Header("Animation"), Tooltip("Название анимации атаки.")]
        public string AnimationAttackName = "EnemyAttack";

        [Header("Respawn"), Tooltip("Время, через которое появляется новый враг, в секундах.")]
        public float RespawnTime = 3f;
    }
}
