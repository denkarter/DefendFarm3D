using UnityEngine;

namespace DefaultNamespace.Plants
{
    public class PlodSpawner: MonoBehaviour
    {
        [SerializeField] private GameObject m_plodGameObject;
        [SerializeField] private float spawnInterval = 7.0f;
        [SerializeField] private Transform m_wereToSpawn;
        
        private float timeSinceLastSpawn = 0.0f;

        void Update()
        {
            timeSinceLastSpawn += Time.deltaTime;

            if (timeSinceLastSpawn >= spawnInterval)
            {
                Spawn();
                timeSinceLastSpawn = 0.0f;
            }
        }

        void Spawn()
        {
            GameObject newObject = Instantiate(m_plodGameObject, m_wereToSpawn.position, Quaternion.identity);
        }
    }
}