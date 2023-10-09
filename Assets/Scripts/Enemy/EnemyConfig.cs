using System;
using UnityEngine;

namespace Enemy
{
    [Serializable]
    public class EnemyConfig
    {
        [SerializeField] private Enemy _prefab;
        [SerializeField, Range(1, 10)] private int _health;
        [SerializeField, Range(1, 10)] private int _speed;

        public Enemy Prefab => _prefab;
        public int Health => _health;
        public int Speed => _speed;
    }
}