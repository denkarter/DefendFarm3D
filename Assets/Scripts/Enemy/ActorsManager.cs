using System;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class ActorsManager: MonoBehaviour
    {
        public List<Enemy> CurrentEnemies;
        public List<GameObject> Plants;
        public List<GameObject> KillerPlants;
        public GameObject Player;

        private void Awake()
        {
            
        }

        private void FixedUpdate()
        {
            for (int i = 0; i < CurrentEnemies.Count; i++)
            {
                if (CurrentEnemies[i].IsDead)
                {
                    CurrentEnemies.RemoveAt(i);
                }
            }
            //Debug.Log(CurrentEnemies.Count);
        }
    }
}