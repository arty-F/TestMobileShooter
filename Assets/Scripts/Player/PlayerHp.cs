using Assets.Scripts.Infrastructure;
using System;
using UnityEngine;

namespace Assets.Scripts.Player
{
    /// <summary>
    /// Хранит значение здоровья игрока.
    /// </summary>
    public class PlayerHp : MonoBehaviour
    {
        #region events

        /// <summary>
        /// Событие, возникающее при получании урона игроком. В параметре оставшееся здровье.
        /// </summary>
        public event Action<float> PlayerTakeDamage;

        #endregion

        #region private fields

        private float currentHp;

        #endregion

        private void Start()
        {
            var serviceLocator = ServiceLocator.Instance;

            currentHp = serviceLocator.ConfigsStorage.PlayerConfig.MaxHp;
        }

        /// <summary>
        /// Нанесение игроку урона.
        /// </summary>
        /// <param name="damage">Количество урона.</param>
        public void TakeDamage(float damage)
        {
            currentHp -= damage;
            PlayerTakeDamage?.Invoke(currentHp);
        }
    }
}
