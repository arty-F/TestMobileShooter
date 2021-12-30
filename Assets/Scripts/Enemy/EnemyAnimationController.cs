using UnityEngine;

namespace Assets.Scripts.Enemy
{
    /// <summary>
    /// Управляет проигрыванием анимации.
    /// </summary>
    public class EnemyAnimationController : MonoBehaviour
    {
        #region const

        /// <summary>
        /// Время перехода между анимациями.
        /// </summary>
        private float _transitionTime = 0.1f;

        /// <summary>
        /// Название анимации атаки.
        /// </summary>
        private string _attackName = "EnemyAttack";

        #endregion

        #region private fields

        [SerializeField]
        private Animator animator;

        #endregion

        /// <summary>
        /// Проигрывание анимации атаки.
        /// </summary>
        public void OnAttack()
        {
            animator.CrossFade(_attackName, _transitionTime);
        }
    }
}
