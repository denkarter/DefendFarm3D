using Enemy;
using UnityEngine;

namespace DefaultNamespace
{
    public class GameManager: MonoBehaviour
    {
        [SerializeField] private EnemySpawner _enemySpawner;
        public static GameManager Instance;

        public Transform m_playerTransform;
        
        private void Awake()
        {
            
            if (Instance == null)
                Instance = this;
            else
                Destroy(gameObject);
            
            _enemySpawner.StartWork();        
            
            DontDestroyOnLoad(gameObject);
        }
    }
}