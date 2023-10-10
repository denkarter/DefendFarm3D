using System;
using System.Collections;
using Enemy;
using UnityEngine;
using UnityEngine.Serialization;

namespace Health
{
    [RequireComponent(typeof(EnemyAnimator))]
    public class EnemyHealth: MonoBehaviour
    {
        public int MaxHealth;
        public int CurrentHealth;
        public EnemyAnimator Animator;
        public TriggerObserver TriggerObserver;
        public event Action HealthChanged;

        private void Start()
        {
            TriggerObserver.TriggerEnter += TriggerEnter;
            TriggerObserver.TriggerExit += TriggerExit;
            
        }
        public void TakeDamage(int _damage)
        {
            CurrentHealth -= _damage;
            HealthChanged?.Invoke();

            if (CurrentHealth < 0)
            {
                Die();
            }
        }

        private void Die()
        {
            Animator.PlayDeath();
            StartCoroutine(DestroyTimer());
        }

        private IEnumerator DestroyTimer()
        {
            yield return new WaitForSeconds(3);
            Destroy(gameObject);
        }
        
        private void TriggerEnter(Collider obj)
        {
            //Debug.Log(obj.gameObject.name);
           
            
        }

        private void TriggerExit(Collider obj)
        {
            
        }
    }
}