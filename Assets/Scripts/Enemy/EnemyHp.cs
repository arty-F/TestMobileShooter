using Assets.Scripts.Infrastructure;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    /// <summary>
    /// Отвечает за хранение значения здоровья и нанесение урона врагу.
    /// </summary>
    public class EnemyHp : MonoBehaviour
    {
        #region private fields

        private float currentHp;

        [SerializeField]
        private GameObject rootObject;

        [SerializeField]
        private EnemyCoinDropper coinDropper;

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
                coinDropper.DropCoin();
                rootObject.SetActive(false);
                Destroy(rootObject);
            }
        }
    }
}
