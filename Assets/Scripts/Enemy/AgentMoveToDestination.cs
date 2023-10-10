using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy
{
    public class AgentMoveToDestination: MonoBehaviour
    {
        public NavMeshAgent Agent;
        private List<GameObject> _plantsDestinations;
        private List<GameObject> _killerPlantsDestinations;
        private GameObject _player;
        private int _indexOfPlantsDestination;
        private int _indexOfKillerPlantsDestination;
        //private string _nameOfDestination;
        public float MinimalDistance = 0.8f;
        private DestinationType _destinationType;
        private ActorsManager _actorsManager;
        private Aggro _aggro;
        private GameObject _closest;

        private void Start()
        {
            _actorsManager = FindObjectOfType<ActorsManager>();
            _killerPlantsDestinations = _actorsManager.KillerPlants;
            _plantsDestinations = _actorsManager.Plants;
            _player = _actorsManager.Player;
            _aggro = GetComponent<Aggro>();

            // _killerPlantsDestinations = _actorsManager.KillerPlants;
            // if (_killerPlantsDestinations != null && _killerPlantsDestinations.Count != 0)
            // {
            //     _indexOfKillerPlantsDestination = UnityEngine.Random.Range(0, _killerPlantsDestinations.Count);
            // }
            
            
            
            
            
            
            _destinationType = DestinationType.Plants;
            Debug.Log("_destinationType at Start: " + _destinationType);
        }

        private void Update()
        {
            if (_destinationType == DestinationType.Plants)
            {
                MoveToPlants();
            }

            if (_destinationType == DestinationType.Player)
            {
                MoveToPlayer();
            }

            if (_destinationType == DestinationType.KillerPlants)
            {
                MoveToKillerPlants();
            }
            
        }

        private void MoveToKillerPlants()
        {
            if (_aggro.IsTriggered)
            {
                GameObject closestObj = FindClosestObject(_killerPlantsDestinations);
                if (Vector3.Distance(Agent.transform.position, closestObj.transform.position) >= MinimalDistance)
                {
                    Agent.destination = closestObj.transform.position;
                }
            }
            if (!_aggro.IsTriggered && _killerPlantsDestinations != null && _killerPlantsDestinations.Count != 0)
            {
                _indexOfKillerPlantsDestination = UnityEngine.Random.Range(0, _killerPlantsDestinations.Count);
                if (Vector3.Distance(Agent.transform.position, _killerPlantsDestinations[_indexOfKillerPlantsDestination].transform.position) >= MinimalDistance)
                {
                    Agent.destination = _killerPlantsDestinations[_indexOfKillerPlantsDestination].transform.position;
                }
                
            }
        }

        private GameObject FindClosestObject(List<GameObject> list)
        {
            float distance = Mathf.Infinity;
            Vector3 position = transform.position;
            foreach (var element in list)
            {
                Vector3 diff = element.transform.position - position;
                float CurrentDistance = diff.sqrMagnitude;
                if (CurrentDistance < distance)
                {
                    _closest = element;
                    distance = CurrentDistance;
                }
            }
            return _closest;
        }

        private void MoveToPlayer()
        {
            if (_actorsManager.Player != null)
            {
                if (Vector3.Distance(Agent.transform.position, _actorsManager.Player.transform.position) >= MinimalDistance)
                {
                    Agent.destination = _player.transform.position;
                }
            }
        }

        private void MoveToPlants()
        {
            if (_aggro.IsTriggered)
            {
                GameObject closestObj = FindClosestObject(_plantsDestinations);
                if (Vector3.Distance(Agent.transform.position, closestObj.transform.position) >= MinimalDistance)
                {
                    Agent.destination = closestObj.transform.position;
                }
            }
            
            if (!_aggro.IsTriggered && _plantsDestinations != null && _plantsDestinations.Count !=0)
            {
                _indexOfPlantsDestination = UnityEngine.Random.Range(0, _plantsDestinations.Count);
                //Debug.Log("_indexOfPlantsDestination: " + _indexOfPlantsDestination);
                if (Vector3.Distance(Agent.transform.position, _plantsDestinations[_indexOfPlantsDestination].transform.position) >= MinimalDistance)
                {
                    Agent.destination = _plantsDestinations[_indexOfPlantsDestination].transform.position;
                }
            }
        }

        public void ChangeDestination(DestinationType destination)
        {
            _destinationType = destination;
        } 
    }
}