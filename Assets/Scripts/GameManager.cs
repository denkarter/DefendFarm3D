using Enemy;
using UniRx;
using UnityEngine;

namespace DefaultNamespace
{
    [DefaultExecutionOrder(-1)]
    public class GameManager: MonoBehaviour
    {
        [SerializeField] private EnemySpawner _enemySpawner;
        public static GameManager Instance;

        [Tooltip("Стартовые значения")]
        [SerializeField] private int m_maxWaterAmount;
        [SerializeField] private int m_restoreHpByWaterPerHit;
        [SerializeField] private int m_decreaseWaterPerPour;
        [SerializeField] private float m_maxDistanceToRefillWater;
        [SerializeField] private float m_maxDistanceToRestorePlantHp;
        [SerializeField] private Camera m_upperCamera;
        
        public Camera upperCamera => m_upperCamera;
        
        public Transform m_playerTransform;

        // Если вам нужно изменить значение кол-ва монет, то пишите 
        // следующее: m_coins.Value = 2 и оно поменяется на 2
        [HideInInspector] public ReactiveProperty<int> m_coins;
        
        // Лейка
        [HideInInspector] public ReactiveProperty<int> maxWaterAmount;
        [HideInInspector] public ReactiveProperty<int> currentWaterAmount;
        [HideInInspector] public ReactiveProperty<float> maxDistanceToRefillWater;
        [HideInInspector] public ReactiveProperty<float> maxDistanceToRestorePlantHp;
        [HideInInspector] public ReactiveProperty<int> restoreHpPerHit;
        [HideInInspector] public ReactiveProperty<int> decreaseWaterPerPour;

        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(gameObject);

            m_coins = new ReactiveProperty<int>();
            maxWaterAmount = new ReactiveProperty<int>(m_maxWaterAmount);
            currentWaterAmount = new ReactiveProperty<int>(m_maxWaterAmount);
            restoreHpPerHit = new ReactiveProperty<int>(m_restoreHpByWaterPerHit);
            maxDistanceToRefillWater = new ReactiveProperty<float>(m_maxDistanceToRefillWater);
            maxDistanceToRestorePlantHp = new ReactiveProperty<float>(m_maxDistanceToRestorePlantHp);
            decreaseWaterPerPour = new ReactiveProperty<int>(m_decreaseWaterPerPour);
            
            _enemySpawner.StartWork();        
            
            DontDestroyOnLoad(gameObject);
        }

        #region Leika i Voda
        
        public void AddMaxWaterAmount(int _addValue)
        {
            maxWaterAmount.Value += _addValue;
        }
        
        public void IncreaseCurrentWaterAmount(int _value)
        {
            currentWaterAmount.Value += _value;
            if (currentWaterAmount.Value > m_maxWaterAmount)
                currentWaterAmount.Value = m_maxWaterAmount;
        }
        
        public void DecreaseCurrentWaterAmount(int _value)
        {
            currentWaterAmount.Value -= _value;
            if (currentWaterAmount.Value < 0)
                currentWaterAmount.Value = 0;
        }

        #endregion
    }
}