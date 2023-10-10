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

        [Header("Стартовые значения")]
        [Header("Строительство")]
        [SerializeField] private int m_turretPrice = 30;
        [Header("Вода")]
        [SerializeField] private int m_maxWaterAmount = 30;
        [SerializeField] private int m_restoreHpByWaterPerHit = 10;
        [SerializeField] private int m_decreaseWaterPerPour = 5;
        [SerializeField] private float m_maxDistanceToRefillWater = 3;
        [SerializeField] private float m_maxDistanceToRestorePlantHp = 3;
        [SerializeField] private int m_upgradingWateringCanValue = 2;
        [Header("Продажа плодов")]
        [SerializeField] private int m_addSellCostCount = 1;
        [SerializeField] private int m_plodSellingCost = 7;
        [Header("Звуки")]
        [SerializeField] private AudioClip m_collectPlodSound;

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
        [HideInInspector] public ReactiveProperty<int> addSellCostCount;
        [HideInInspector] public ReactiveProperty<int> plodSellingCost;
        [HideInInspector] public ReactiveProperty<int> upgradingWateringCanValue;
        [HideInInspector] public ReactiveProperty<int> turretPrice;
        
        public ReactiveCommand showNotEnoughtText;

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
            
            upgradingWateringCanValue = new ReactiveProperty<int>(m_upgradingWateringCanValue);
            
            addSellCostCount = new ReactiveProperty<int>(m_addSellCostCount);
            plodSellingCost = new ReactiveProperty<int>(m_plodSellingCost);
            turretPrice = new ReactiveProperty<int>(m_turretPrice);

            showNotEnoughtText = new ReactiveCommand();
            
            if (_enemySpawner)
                _enemySpawner.StartWork();
            
            DontDestroyOnLoad(gameObject);
        }

        public void PlayCollectCoinSound()
        {
            AudioSource.PlayClipAtPoint(m_collectPlodSound, m_playerTransform.position);
        }

        #region Leika i Voda
        
        public void AddMaxWaterAmount(int _addValue)
        {
            maxWaterAmount.Value += _addValue;
        }
        
        public void IncreaseCurrentWaterAmount(int _value)
        {
            currentWaterAmount.Value += _value;
            if (currentWaterAmount.Value > maxWaterAmount.Value)
                currentWaterAmount.Value = maxWaterAmount.Value;
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