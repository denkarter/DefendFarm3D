using Enemy;
using UnityEngine;

namespace Health
{
    public class EnemyHealth: MonoBehaviour
    {
        private int _maxHealth;
        private int _currentHealth;

        public int MaxHealth
        {
            get => _currentHealth;
            set
            {
                _maxHealth = value;
            }
        }
        
        public EnemyHealth(int health)
        {
            MaxHealth = health;
            _currentHealth = MaxHealth;
        }

        public void GetDamage(int _damage)
        {
        }
    }
}