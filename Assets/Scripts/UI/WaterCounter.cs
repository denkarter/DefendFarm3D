using TMPro;
using UniRx;
using UnityEngine;

namespace DefaultNamespace
{
    public class WaterCounter: MonoBehaviour
    {
        [SerializeField] private TMP_Text m_currentWaterText;
        [SerializeField] private TMP_Text m_maxWaterText;

        private void Awake()
        {
            GameManager.Instance.currentWaterAmount.Subscribe(x => m_currentWaterText.text = x.ToString());
            GameManager.Instance.maxWaterAmount.Subscribe(x => m_maxWaterText.text = x.ToString());
        }
    }
}