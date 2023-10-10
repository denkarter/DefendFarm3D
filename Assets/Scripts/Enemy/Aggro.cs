using System;
using System.Collections;
using UnityEngine;

namespace Enemy
{
    public class Aggro: MonoBehaviour
    {
        public TriggerObserver TriggerObserver;
        public AgentMoveToDestination Follow;
        public float CoolDown;
        private Coroutine _aggroCoroutine;
        private bool _hasAggroTarget;
        public bool IsTriggered = false;

        private void Start()
        {
            TriggerObserver.TriggerEnter += TriggerEnter;
            TriggerObserver.TriggerExit += TriggerExit;
            //Follow.enabled = false;
        }

        private void TriggerEnter(Collider obj)
        {
            IsTriggered = true;
            if (!_hasAggroTarget)
            {
                _hasAggroTarget = true;
                
                if (_aggroCoroutine != null)
                {
                    StopCoroutine(_aggroCoroutine);
                }
            
                if (obj.gameObject.CompareTag("Player"))
                {
                    //Debug.Log("Player touched");
                    Follow.ChangeDestination(DestinationType.Player);
                }
                if (obj.gameObject.CompareTag("Plants"))
                {
                    //Debug.Log("Plants touched");
                    Follow.ChangeDestination(DestinationType.Plants);
                }
                if (obj.gameObject.CompareTag("KillerPlants"))
                {
                    //Debug.Log("KillerPlants touched");
                    Follow.ChangeDestination(DestinationType.KillerPlants);
                }
                //Follow.enabled = true;
            }
           
        }

        private void TriggerExit(Collider obj)
        {
            if (_hasAggroTarget)
            {
                _hasAggroTarget = false;
                _aggroCoroutine = StartCoroutine(SwitchFollowAfterCooldown());
            }
            //Follow.enabled = false;
        }

        private IEnumerator SwitchFollowAfterCooldown()
        {
            yield return new WaitForSeconds(CoolDown);
            Follow.ChangeDestination(DestinationType.Plants);
        }
    }
}