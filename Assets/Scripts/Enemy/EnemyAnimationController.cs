using Assets.Scripts.Infrastructure;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    /// <summary>
    /// Управляет проигрыванием анимации.
    /// </summary>
    public class EnemyAnimationController : MonoBehaviour
    {
        #region private fields

        [SerializeField]
        private Animator animator;

        private float transitionTime;

        private string attackName;

        #endregion

        private void Start()
        {
            var serviceLocator = ServiceLocator.Instance;

            transitionTime = serviceLocator.ConfigsStorage.EnemyConfig.AnimationTransitionTime;
            attackName = serviceLocator.ConfigsStorage.EnemyConfig.AnimationAttackName;
        }

        /// <summary>
        /// Проигрывание анимации атаки.
        /// </summary>
        public void OnAttack()
        {
            animator.CrossFade(attackName, transitionTime);
        }
    }
}
