using Assets.Scripts.Infrastructure;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    /// <summary>
    /// Отображает значение здоровья игрока.
    /// </summary>
    public class PlayerHpPanel : MonoBehaviour
    {
        #region private fields

        [SerializeField]
        private Text textHp;

        #endregion


        private void Start()
        {
            var serviceLocator = ServiceLocator.Instance;

            textHp.text = GetHpStr(serviceLocator.ConfigsStorage.PlayerConfig.MaxHp);

            serviceLocator.PlayerHp.PlayerTakeDamage += OnHpChanged;
        }

        private void OnHpChanged(float currentHp)
        {
            if (currentHp > 0)
            {
                textHp.text = GetHpStr(currentHp);
            }
            else
            {
                textHp.text = "0";
            }
        }

        /// <summary>
        /// Округляет в большую сторону и возвращает строковое представление.
        /// </summary>
        private string GetHpStr(float hp)
        {
            return Mathf.FloorToInt(hp).ToString();
        }
    }
}
