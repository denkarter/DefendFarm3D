using UniRx;
using UnityEngine;

namespace DefaultNamespace
{
    public class GameManager: MonoBehaviour
    {
        public static GameManager Instance;

        public Transform m_playerTransform;
        // Если вам нужно изменить значение кол-ва монет, то пишите 
        // следующее: m_coins.Value = 2 и оно поменяется на 2
        public ReactiveProperty<int> m_coins;
        
        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(gameObject);

            m_coins = new ReactiveProperty<int>();
            
            DontDestroyOnLoad(gameObject);
        }
    }
}