using Assets.Scripts.Coin;
using Assets.Scripts.Infrastructure;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    /// <summary>
    /// Отвечает за выкидывание награды после уничтожения врага.
    /// </summary>
    class EnemyCoinDropper : MonoBehaviour
    {
        #region private fields

        private CoinFactory coinFactory;

        #endregion

        private void Start()
        {
            var serviceLocator = ServiceLocator.Instance;

            coinFactory = serviceLocator.CoinFactory;
        }

        /// <summary>
        /// Выбросить награду за уничтожение противника.
        /// </summary>
        public void DropCoin()
        {
            coinFactory.CreateCoin(gameObject.transform.position);
        }
    }
}
