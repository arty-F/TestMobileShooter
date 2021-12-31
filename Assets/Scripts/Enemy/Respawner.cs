using Assets.Scripts.Infrastructure;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    /// <summary>
    /// Создает врагов в игровой области.
    /// </summary>
    public class Respawner : MonoBehaviour
    {
        #region const

        private const int _pointVisibilityCheckAttempts = 10;

        #endregion

        #region private fields

        private GameObject enemyPrefab;

        private float minRespawnTime;

        private float maxRespawnTime;

        [SerializeField]
        private Transform[] respawnPoints;

        private Renderer[] respawnRenderers;

        [SerializeField]
        private Camera mainCamera;

        #endregion

        private void Awake()
        {
            respawnRenderers = new Renderer[respawnPoints.Length];

            for (int i = 0; i < respawnPoints.Length; i++)
            {
                respawnRenderers[i] = respawnPoints[i].gameObject.GetComponent<Renderer>();
            }
        }

        private void Start()
        {
            var config = ServiceLocator.Instance.ConfigsStorage.EnemyConfig;

            enemyPrefab = config.Prefab;

            //В среднем враги будут создаваться раз в 3 секунды как и нужно. Использую случайное смещение по времени,
            //чтобы просчет поиска путей у навмеша, при обновлении destination не происходил в один кадр для всех врагов.
            var halfNavMeshRefreshTime = config.NavMeshDestRefreshTime * 0.5f;
            minRespawnTime = config.RespawnTime - halfNavMeshRefreshTime;
            maxRespawnTime = config.RespawnTime + halfNavMeshRefreshTime;

            StartCoroutine(WaitAndCreateEnemy());
        }

        private IEnumerator WaitAndCreateEnemy()
        {
            yield return new WaitForSeconds(Random.Range(minRespawnTime, maxRespawnTime));

            GameObject.Instantiate(enemyPrefab, GetNextRespawnPosition(), Quaternion.identity);

            StartCoroutine(WaitAndCreateEnemy());
        }

        private Vector3 GetNextRespawnPosition()
        {
            int i;
            int attempts = _pointVisibilityCheckAttempts;

            do
            {
                i = Random.Range(0, respawnPoints.Length);
                attempts--;
            } while (respawnRenderers[i].isVisible && attempts > 0);

            return respawnPoints[i].position;
        }

        private void OnDestroy()
        {
            StopAllCoroutines();
        }
    }
}
