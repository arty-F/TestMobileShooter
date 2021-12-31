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

        private GameObject bulletPrefab;

        [SerializeField]
        private GameObject mainCamera;

        #endregion

        private void Start()
        {
            var serviceLocator = ServiceLocator.Instance;

            bulletPrefab = serviceLocator.ConfigsStorage.BulletConfig.Prefab;
        }

        public void CreateBullet()
        {
            Instantiate(bulletPrefab, transform.position, mainCamera.transform.rotation);
        }
    }
}
