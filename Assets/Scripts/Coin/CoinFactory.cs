using Assets.Scripts.Infrastructure;
using UnityEngine;

namespace Assets.Scripts.Coin
{
    /// <summary>
    /// Создает подбираемые игроком бонусы.
    /// </summary>
    public class CoinFactory : MonoBehaviour
    {
        #region

        private GameObject coinPrefab;

        private Color[] colors;

        #endregion

        private void Awake()
        {
            colors = new Color[]
            {
                Color.red,
                Color.yellow,
                Color.green
            };
        }

        private void Start()
        {
            var serviceLocator = ServiceLocator.Instance;

            coinPrefab = serviceLocator.ConfigsStorage.CoinConfig.Prefab;
        }

        /// <summary>
        /// Создать монету в указанной точке.
        /// </summary>
        public void CreateCoin(Vector3 position)
        {
            var coin = Instantiate(coinPrefab, position, Quaternion.identity).GetComponent<CoinController>();
            coin.SetColor(colors[Random.Range(0, colors.Length)]);
        }
    }
}
