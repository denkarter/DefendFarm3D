using UnityEngine;

namespace DefaultNamespace
{
    public class GameManager: MonoBehaviour
    {
        public static GameManager Instance;

        public Transform m_playerTransform;
        
        private void Awake()
        {
            
            if (Instance == null)
                Instance = this;
            else
                Destroy(gameObject);
            
            DontDestroyOnLoad(gameObject);
        }
    }
}