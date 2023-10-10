using System;
using Enemy;
using UnityEngine;
using UnityEngine.Serialization;

namespace Health
{
    public class EnemyHealth: MonoBehaviour
    {
        public int MaxHealth;
        public int CurrentHealth;
        public event Action HealthChanged;

        public void GetDamage(int _damage)
        {
            CurrentHealth -= _damage;
            HealthChanged?.Invoke();
        }
        
        
    }
}