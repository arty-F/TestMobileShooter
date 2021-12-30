using Assets.Scripts.Infrastructure;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.Enemy
{
    /// <summary>
    /// Отвечает за управление NavMeshAgent'ом, а фактические за перемещение юнита.
    /// </summary>
    public class EnemyMoveController : MonoBehaviour
    {
        #region private fields

        [SerializeField]
        private NavMeshAgent meshAgent;

        private GameObject player;

        private float navMeshDestRefreshTime;

        #endregion

        private void Start()
        {
            var serviceLocator = ServiceLocator.Instance;

            player = serviceLocator.Player;
            navMeshDestRefreshTime = serviceLocator.ConfigsStorage.EnemyConfig.NavMeshDestRefreshTime;

            ContinueMove();
        }

        /// <summary>
        /// Останавливает следование за игроком.
        /// </summary>
        public void StopMove()
        {
            meshAgent.isStopped = true;
            StopAllCoroutines();
        }

        /// <summary>
        /// Продолжает следование за игроком.
        /// </summary>
        public void ContinueMove()
        {
            StartCoroutine(WaitAndSetDestination(navMeshDestRefreshTime));
        }

        private IEnumerator WaitAndSetDestination(float delay)
        {
            yield return new WaitForSeconds(delay);

            meshAgent.SetDestination(player.transform.position);

            ContinueMove();
        }

        private void OnDestroy()
        {
            StopMove();
        }
    }
}
