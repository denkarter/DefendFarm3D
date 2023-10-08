using TMPro;
using UniRx;
using UnityEngine;

namespace DefaultNamespace
{
    public class CoinsCounter: MonoBehaviour
    {
        [SerializeField] private TMP_Text m_textCounter;

        private void Awake()
        {
            GameManager.Instance.m_coins.Subscribe(SetCoinsCount);
        }

        private void SetCoinsCount(int _count)
        {
            m_textCounter.text = _count.ToString();
        }
    }
}