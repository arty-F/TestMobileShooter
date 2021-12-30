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
        #region const

        /// <summary>
        /// Время через которое обновляется destination у navMeshAgent
        /// </summary>
        private const float _navMeshDestRefreshTime = 0.5f;

        #endregion

        #region private fields

        [SerializeField]
        private NavMeshAgent meshAgent;

        private GameObject player;

        #endregion

        private void Start()
        {
            var serviceLocator = ServiceLocator.Instance;

            player = serviceLocator.Player;

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
            StartCoroutine(WaitAndSetDestination(_navMeshDestRefreshTime));
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
