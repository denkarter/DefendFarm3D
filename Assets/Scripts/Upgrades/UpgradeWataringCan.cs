using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace.Upgrades
{
    public class UpgradeWataringCan: MonoBehaviour
    {
        [SerializeField] private int m_upgradeCost;
        [SerializeField] private TMP_Text m_textCost;
        [SerializeField] private Button m_buyButton;

        private void Awake()
        {
            m_textCost.text = m_upgradeCost.ToString();
            m_buyButton.onClick.AddListener(BuyAction);
        }

        private void BuyAction()
        {
            if (GameManager.Instance.m_coins.Value >= m_upgradeCost)
            {
                GameManager.Instance.m_coins.Value -= m_upgradeCost;
                GameManager.Instance.maxWaterAmount.Value += GameManager.Instance.upgradingWateringCanValue.Value;
            }
        }
    }
}