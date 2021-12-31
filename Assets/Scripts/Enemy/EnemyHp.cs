using Assets.Scripts.Infrastructure;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    /// <summary>
    /// Отвечает хранение значения здоровья за нанесение урона врагу.
    /// </summary>
    public class EnemyHp : MonoBehaviour
    {
        #region private fields

        private float currentHp;

        [SerializeField]
        private GameObject rootObject;

        #endregion

        private void Start()
        {
            var serviceLocator = ServiceLocator.Instance;

            currentHp = serviceLocator.ConfigsStorage.EnemyConfig.MaxHp;
        }

        /// <summary>
        /// Нанесение урона врагу.
        /// </summary>
        /// <param name="damage">Количество урона.</param>
        public void TakeDamage(float damage)
        {
            currentHp -= damage;

            if (currentHp <= 0f)
            {
                rootObject.SetActive(false);
                Destroy(rootObject);
            }
        }
    }
}
