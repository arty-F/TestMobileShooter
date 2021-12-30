using Assets.Scripts.Infrastructure.ScriptableObjects;
using UnityEngine;

namespace Assets.Scripts.Infrastructure
{
    /// <summary>
    /// Хранилище конфигов.
    /// </summary>
    public class ConfigsStorage : MonoBehaviour
    {
        [SerializeField]
        public PlayerConfig PlayerConfig;

        [SerializeField]
        public EnemyConfig EnemyConfig;
    }
}
