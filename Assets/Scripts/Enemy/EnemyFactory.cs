using System;
using UnityEngine;

namespace Enemy
{
    [CreateAssetMenu(fileName = "EnemyFactory", menuName = "Factory/EnemyFactory")]
    public class EnemyFactory: ScriptableObject
    {
        [SerializeField] private EnemyConfig _zombie;
        [SerializeField] private EnemyConfig _ork;

        public Enemy Get(EnemyType enemyType)
        {
            EnemyConfig enemyConfig = GetConfig(enemyType);
            Enemy enemy = Instantiate(enemyConfig.Prefab);
            enemy.Initialize(enemyConfig.Health, enemyConfig.Speed);
            return enemy;
        }

        private EnemyConfig GetConfig(EnemyType enemyType)
        {
            switch (enemyType)
            {
                case EnemyType.Ork:
                    return _ork;
                case EnemyType.Zombie:
                    return _zombie;
                default:
                    throw new ArgumentException(nameof(enemyType));
            }
        }
    }
}