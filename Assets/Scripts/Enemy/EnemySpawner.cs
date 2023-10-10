using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

namespace Enemy
{
    public class EnemySpawner: MonoBehaviour
    {
        [SerializeField, Range(1, 10)] private float _spawnCooldown;
        [SerializeField] private List<Transform> _spawnPoints;
        [SerializeField] private EnemyFactory _enemyFactory;
        [SerializeField] private int _maxEnemyCounter;
        [FormerlySerializedAs("_enemyManager")] [SerializeField] private ActorsManager _actorsManager;
        private int _enemyCounter;

        private Coroutine _spawn;

        public void StartWork()
        {
            StopWork();
            if (_enemyCounter < _maxEnemyCounter)
            {
                _spawn = StartCoroutine(Spawn());
            }
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
            Enemy enemy = _enemyFactory.Get((EnemyType)UnityEngine.Random.Range(0, Enum.GetValues(typeof(EnemyType)).Length));
            if (enemy.TryGetComponent<NavMeshAgent>(out NavMeshAgent agent))
            {
                agent.Warp(_spawnPoints[UnityEngine.Random.Range(0, _spawnPoints.Count)].position);
            }
            _enemyCounter++;
            _actorsManager.CurrentEnemies.Add(enemy);
            yield return new WaitForSeconds(_spawnCooldown);
         }

        private void Start()
        {
            _enemyCounter = 0;
        }

        private void Update()
        {
            if (_enemyCounter < _maxEnemyCounter)
            {
                StartWork();
            }
        }
    }
}