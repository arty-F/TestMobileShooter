using Assets.Scripts.Infrastructure;
using UnityEngine;

namespace Assets.Scripts.Player
{
    /// <summary>
    /// Отвечает за создание снарядов игрока.
    /// </summary>
    public class PlayerBulletFactory : MonoBehaviour
    {
        #region private fields

        private Color lastCollectedColor;

        private GameObject bulletPrefab;

        [SerializeField]
        private GameObject mainCamera;

        #endregion

        private void Awake()
        {
            lastCollectedColor = Color.white;
        }

        private void Start()
        {
            var serviceLocator = ServiceLocator.Instance;

            bulletPrefab = serviceLocator.ConfigsStorage.BulletConfig.Prefab;

            serviceLocator.PlayerCoinCollector.CoinCollected += OnCoinCollected;
        }

        public void CreateBullet()
        {
            var bullet = Instantiate(bulletPrefab, transform.position, mainCamera.transform.rotation)
                .GetComponent<PlayerBulletController>();

            bullet.SetColor(lastCollectedColor);
        }

        /// <summary>
        /// Обработчик подбора монет игроком.
        /// </summary>
        private void OnCoinCollected(Color color)
        {
            lastCollectedColor = color;
        }
    }
}
