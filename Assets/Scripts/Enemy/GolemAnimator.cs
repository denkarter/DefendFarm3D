using System;
using UnityEngine;

namespace Enemy
{
    public class GolemAnimator: MonoBehaviour
    {
        private static readonly int Dead = Animator.StringToHash("Dead");
        private static readonly int Attack1 = Animator.StringToHash("Attack1");
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
            _animator.SetTrigger(Attack1);
        }
    }
}