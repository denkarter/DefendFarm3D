using System;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy
{
    public class AgentMoveToPlant: MonoBehaviour
    {
        public NavMeshAgent Agent;
        public GameObject EnemyDestination;
        public float MinimalDistance = 0.4f;

        private void Awake()
        {
            EnemyDestination = GameObject.FindGameObjectWithTag("DestinationForEnemies");
        }

        private void Update()
        {
            if (Vector3.Distance(Agent.transform.position, EnemyDestination.transform.position) >= MinimalDistance)
            {
                Agent.destination = EnemyDestination.transform.position;
                
            }

        }
    }
}