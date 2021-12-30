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
        #region private fields

        private GameObject enemyPrefab;

        private float minRespawnTime;

        private float maxRespawnTime;

        #endregion

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

            var pos = new Vector3(0f, 0f, 0f);
            GameObject.Instantiate(enemyPrefab, pos, Quaternion.identity);

            StartCoroutine(WaitAndCreateEnemy());
        }

        private void OnDestroy()
        {
            StopAllCoroutines();
        }
    }
}
