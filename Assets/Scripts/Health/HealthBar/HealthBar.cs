using UnityEngine;
using UnityEngine.UI;

public class HealthBar: MonoBehaviour
{
    [SerializeField] private Image m_barImage;

    public void SetBarValue(float _barValue)
    {
        m_barImage.fillAmount = _barValue;
    }
}