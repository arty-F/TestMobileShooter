using Assets.Scripts.Player;
using UnityEngine;

namespace Assets.Scripts.Infrastructure
{
    /// <summary>
    /// Предоставляет доступ к компонентам игры сцены "Level". Использую как заглушку di библиотеки, чтобы
    /// не тянуть всякие ninject'ы в тестовое задание. При надобности сюда можно инжектить сервисы другим способом,
    /// при этом остальной код не нужно будет переписывать.
    /// </summary>
    public class ServiceLocator : MonoBehaviour
    {
        public static ServiceLocator Instance { get; private set; } = null;

        #region public fields

        [SerializeField]
        public GameObject Player;

        [SerializeField]
        public PlayerHp PlayerHp;

        [SerializeField]
        public ConfigsStorage ConfigsStorage;

        #endregion

        private void Awake()
        {
            Instance = this;
        }
    }
}
