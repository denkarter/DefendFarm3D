using System;
using Health;
using UnityEngine;

namespace Enemy
{
    public class Enemy: MonoBehaviour
    {
        private EnemyHealth _health;
        private int _speed;

        private void Awake()
        {
            _health = GetComponent<EnemyHealth>();
        }

        public void Initialize(int health, int speed)
        {
            _health.MaxHealth = health;
            _speed = speed;
        }

        public void SpawnTo(Vector3 position)
        {
            transform.position = position;
        }
    }
}