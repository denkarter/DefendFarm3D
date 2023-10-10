
using System;
using Health;
using UnityEngine;

namespace Enemy
{
    public class Enemy: MonoBehaviour
    {
        private EnemyHealth _health;
        private EnemyDeath _enemyDeath;
        private int _speed;
        public Action EnemyCreated;
        public bool IsDead = false;
        //public DestinationType DestinationType;

        private void Awake()
        {
            //DestinationType = DestinationType.Plants;
            _health = GetComponent<EnemyHealth>();
            _enemyDeath = GetComponent<EnemyDeath>();
        }

        private void Start()
        {
            _enemyDeath.EnemyDied += EnemyDied;
        }

        private void EnemyDied()
        {
            IsDead = true;
        }

        public void Initialize(int health, int speed)
        {
            _health.MaxHealth = health;
            _health.CurrentHealth = health;
            _speed = speed;
            EnemyCreated?.Invoke();
        }

        public void SpawnTo(Vector3 position)
        {
            transform.position = position;
        }
    }
}