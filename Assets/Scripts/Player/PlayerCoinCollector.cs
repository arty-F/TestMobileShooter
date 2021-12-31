using Assets.Scripts.Coin;
using System;
using UnityEngine;

namespace Assets.Scripts.Player
{
    /// <summary>
    /// Отвечает за подбор выпадаемых с противников монет.
    /// </summary>
    public class PlayerCoinCollector : MonoBehaviour
    {
        #region events

        /// <summary>
        /// Событие, возникающее при подборе игроком монетки. В параметре цвет подобранной монетки.
        /// </summary>
        public event Action<Color> CoinCollected;

        #endregion

        private void OnTriggerEnter(Collider collision)
        {
            var coin = collision.gameObject.GetComponent<CoinController>();
            CoinCollected?.Invoke(coin.GetColor());

            collision.gameObject.SetActive(false);
            Destroy(collision.gameObject);
        }
    }
}
