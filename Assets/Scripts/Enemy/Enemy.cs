using System;
using UnityEngine;

namespace Enemy
{
    public class Enemy: MonoBehaviour
    {
        private float _health;
        private float _speed;
        
        public void Initialize(float health, float speed)
        {
            _health = health;
            _speed = speed;
        }

        public void SpawnTo(Vector3 position)
        {
            transform.position = position;
        }
    }
}