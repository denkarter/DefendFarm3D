using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class EnemySpawner: MonoBehaviour
    {
        [SerializeField, Range(1, 10)] private float _spawnCooldown;
        [SerializeField] private List<Transform> _spawnPoints;
        [SerializeField] private EnemyFactory _enemyFactory;

        private Coroutine _spawn;

        public void StartWork()
        {
            StopWork();
            _spawn = StartCoroutine(Spawn());
        }

        public void StopWork()
        {
            if (_spawn != null)
            {
                StopCoroutine(_spawn);
            }
        }

        IEnumerator Spawn()
        {
            while (true)
            {
                Enemy enemy = _enemyFactory.Get((EnemyType)UnityEngine.Random.Range(0, Enum.GetValues(typeof(EnemyType)).Length));
                enemy.SpawnTo(_spawnPoints[UnityEngine.Random.Range(0, _spawnPoints.Count)].position);
                yield return new WaitForSeconds(_spawnCooldown);
            }
        }
    }
}