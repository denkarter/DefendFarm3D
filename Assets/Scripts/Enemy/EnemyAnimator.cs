using UnityEngine;

namespace Enemy
{
    public class EnemyAnimator: MonoBehaviour
    {
        private static readonly int Dead = Animator.StringToHash("Dead");
        private static readonly int Attack2 = Animator.StringToHash("Attack2");
        private Animator _animator;
        
        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void PlayDeath()
        {
            _animator.SetTrigger(Dead);
        }

        public void PlayAttack1()
        {
            _animator.SetTrigger(Attack2);
        }
    }
}