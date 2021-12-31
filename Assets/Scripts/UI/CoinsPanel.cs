using Assets.Scripts.Infrastructure;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    /// <summary>
    /// Отображает значения собранных монеток.
    /// </summary>
    public class CoinsPanel : MonoBehaviour
    {
        #region private fields

        private Dictionary<Color, int> coinsMap;

        private Dictionary<Color, Text> textMap;

        [SerializeField]
        private Text redText;

        [SerializeField]
        private Text yellowText;

        [SerializeField]
        private Text greenText;

        #endregion

        private void Awake()
        {
            coinsMap = new Dictionary<Color, int>()
            {
                {Color.red, 0 },
                {Color.yellow, 0 },
                {Color.green, 0 }
            };

            textMap = new Dictionary<Color, Text>()
            {
                {Color.red, redText },
                {Color.yellow, yellowText },
                {Color.green, greenText }
            };
        }

        private void Start()
        {
            var serviceLocator = ServiceLocator.Instance;

            serviceLocator.PlayerCoinCollector.CoinCollected += OnCoinCollected;
        }

        /// <summary>
        /// Обработчик поднятия монетки игроком.
        /// </summary>
        private void OnCoinCollected(Color color)
        {
            ++coinsMap[color];

            textMap[color].text = coinsMap[color].ToString();
        }
    }
}
