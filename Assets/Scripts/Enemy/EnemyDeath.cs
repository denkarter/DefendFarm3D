using System;
using Health;
using UnityEngine;

namespace Enemy
{
    [RequireComponent(typeof(EnemyAnimator), typeof(EnemyHealth))]
    public class EnemyDeath: MonoBehaviour
    {
        public EnemyHealth Health;
        public EnemyAnimator Animator;
        public event Action EnemyDied;

        private void Start()
        {
            Health.HealthChanged += HealthChanged;
        }

        private void HealthChanged()
        {
            if (Health.CurrentHealth < 0)
            {
                Die();
            }
        }

        private void Die()
        {
            // PlayDeath
            EnemyDied?.Invoke();
            Animator.PlayDeath();
        }

        private void OnDestroy()
        {
            Health.HealthChanged -= HealthChanged;
        }
    }
}