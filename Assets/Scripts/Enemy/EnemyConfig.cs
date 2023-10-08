using System;
using UnityEngine;

namespace Enemy
{
    [Serializable]
    public class EnemyConfig
    {
        [SerializeField] private Enemy _prefab;
        [SerializeField, Range(1, 10)] private float _health;
        [SerializeField, Range(1, 10)] private float _speed;

        public Enemy Prefab => _prefab;
        public float Health => _health;
        public float Speed => _speed;
    }
}