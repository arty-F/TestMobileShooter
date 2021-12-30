using Assets.Scripts.Player;
using UnityEngine;

namespace Assets.Scripts.Infrastructure
{
    /// <summary>
    /// Предоставляет доступ к компонентам игры сцены "Level".
    /// </summary>
    public class ServiceLocator : MonoBehaviour
    {
        public static ServiceLocator Instance { get; private set; } = null;

        #region public fields

        [SerializeField]
        public GameObject Player;

        [SerializeField]
        public PlayerHp PlayerHp;

        #endregion

        private void Awake()
        {
            Instance = this;
        }
    }
}
