using System;
using UnityEngine;

namespace Enemy
{
    [CreateAssetMenu(fileName = "EnemyFactory", menuName = "Factory/EnemyFactory")]
    public class EnemyFactory: ScriptableObject
    {
        [SerializeField] private EnemyConfig _goblin;
        [SerializeField] private EnemyConfig _golem;
        [SerializeField] private EnemyConfig _skeleton;

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
                case EnemyType.Goblin:
                    return _goblin;
                case EnemyType.Golem:
                    return _golem;
                case EnemyType.Skeleton:
                    return _skeleton;
                default:
                    throw new ArgumentException(nameof(enemyType));
            }
        }
    }
}