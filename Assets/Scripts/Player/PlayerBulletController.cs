using Assets.Scripts.Enemy;
using Assets.Scripts.Infrastructure;
using Assets.Scripts.Infrastructure.Enums;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Player
{
    /// <summary>
    /// Задает начальный импульс для полета пули и контролирует коллизии с другими объектами.
    /// </summary>
    public class PlayerBulletController : MonoBehaviour
    {
        #region private fields

        [SerializeField]
        private Rigidbody body;

        private float damage;

        #endregion

        private void Start()
        {
            var config = ServiceLocator.Instance.ConfigsStorage.BulletConfig;

            damage = config.Damage;

            body.AddRelativeForce(config.StartingForce);

            StartCoroutine(WaitAndDestroy(config.LifeTime));
        }

        private IEnumerator WaitAndDestroy(float time)
        {
            yield return new WaitForSeconds(time);

            Destroy(gameObject);
        }

        private void OnTriggerEnter(Collider collision)
        {
            if (collision.gameObject.layer == (int)PhysicLayers.Enemy)
            {
                var enemyHp = collision.gameObject.GetComponent<EnemyHp>();
                enemyHp.TakeDamage(damage);
            }

            Destroy(gameObject);
        }

        private void OnDestroy()
        {
            StopAllCoroutines();
        }
    }
}
