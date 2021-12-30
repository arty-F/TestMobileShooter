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
        #region const

        /// <summary>
        /// Время между атаками в секундах.
        /// </summary>
        private const float _betweenAttackTime = 1f;

        /// <summary>
        /// Урон, наносимый каждой атакой.
        /// </summary>
        private const float _damage = 5f;

        #endregion

        #region private fields

        private bool playerInRange;

        [SerializeField]
        private EnemyMoveController moveController;

        [SerializeField]
        private EnemyAnimationController animationController;

        private PlayerHp playerHp;

        #endregion

        private void Start()
        {
            var serviceLocator = ServiceLocator.Instance;

            playerHp = serviceLocator.PlayerHp;
        }

        private void OnTriggerEnter(Collider other)
        {
            playerInRange = true;
            StartCoroutine(AttackAndWait());
        }

        private void OnTriggerExit(Collider other)
        {
            playerInRange = false;
        }

        private IEnumerator AttackAndWait()
        {
            moveController.StopMove();

            animationController.OnAttack();

            playerHp.TakeDamage(_damage);

            yield return new WaitForSeconds(_betweenAttackTime);

            if (playerInRange)
            {
                StartCoroutine(AttackAndWait());
            }
            else
            {
                moveController.ContinueMove();
            }
        }
    }
}
