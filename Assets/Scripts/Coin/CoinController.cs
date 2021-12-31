using Assets.Scripts.Infrastructure;
using UnityEngine;

namespace Assets.Scripts.Coin
{
    /// <summary>
    /// Управляет поведением созданной, подбираемой игроком награды.
    /// </summary>
    public class CoinController : MonoBehaviour
    {
        #region private fields

        private Color currentColor;

        [SerializeField]
        private Rigidbody body;

        [SerializeField]
        private Renderer renderer;

        #endregion

        private void Start()
        {
            var serviceLocator = ServiceLocator.Instance;

            body.AddForce(serviceLocator.ConfigsStorage.CoinConfig.InitialForce);
            body.AddTorque(serviceLocator.ConfigsStorage.CoinConfig.InitialTorque);
        }

        /// <summary>
        /// Устанавливает цвет выпадающей награды, в соответствии с передаваемым значением.
        /// </summary>
        public void SetColor(Color color)
        {
            currentColor = color;
            renderer.material.color = color;
        }
    }
}
