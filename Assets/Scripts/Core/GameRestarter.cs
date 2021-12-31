using Assets.Scripts.Infrastructure;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Core
{
    /// <summary>
    /// Отвечает за перезагрузку сцены при обнулении здоровья игрока.
    /// </summary>
    public class GameRestarter : MonoBehaviour
    {
        private void Start()
        {
            var serviceLocator = ServiceLocator.Instance;

            serviceLocator.PlayerHp.PlayerTakeDamage += OnHpChanged;
        }
        
        private void OnHpChanged(float currentHp)
        {
            if (currentHp <= 0f)
            {
                RestartCurrentScene();
            }
        }

        private void RestartCurrentScene()
        {
            var scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name, LoadSceneMode.Single);
        }
    }
}
