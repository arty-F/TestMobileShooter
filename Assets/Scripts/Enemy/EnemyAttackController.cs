using Assets.Scripts.Infrastructure;
using Assets.Scripts.Player;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    /// <summary>
    /// Отвечает за атаки врага и нанесение урона игроку.
    /// </summary>
    public class EnemyAttackController : MonoBehaviour
    {
        #region private fields

        [SerializeField]
        private EnemyMoveController moveController;

        [SerializeField]
        private EnemyAnimationController animationController;

        private bool playerInRange;

        private float betweenAttackTime;

        private float damage;

        private PlayerHp playerHp;

        #endregion

        private void Start()
        {
            var serviceLocator = ServiceLocator.Instance;

            playerHp = serviceLocator.PlayerHp;
            betweenAttackTime = serviceLocator.ConfigsStorage.EnemyConfig.AttackBetweenTime;
            damage = serviceLocator.ConfigsStorage.EnemyConfig.AttackDamage;
        }

        private void OnTriggerEnter()
        {
            playerInRange = true;
            StartCoroutine(AttackAndWait());
        }

        private void OnTriggerExit()
        {
            playerInRange = false;
        }

        private IEnumerator AttackAndWait()
        {
            moveController.StopMove();

            animationController.OnAttack();

            playerHp.TakeDamage(damage);

            yield return new WaitForSeconds(betweenAttackTime);

            if (playerInRange)
            {
                StartCoroutine(AttackAndWait());
            }
            else
            {
                moveController.ContinueMove();
            }
        }

        private void OnDestroy()
        {
            StopAllCoroutines();
        }
    }
}
