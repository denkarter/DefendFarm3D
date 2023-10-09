using TMPro;
using UnityEngine;

namespace DefaultNamespace
{
    public class WaterContainer: MonoBehaviour
    {
        [SerializeField] private int m_amountOfWater;
        [SerializeField] private TMP_Text m_amountOfWaterText;
        [SerializeField] private AudioClip m_getWaterSound;
        [SerializeField] private AudioSource m_audioSource;

        public int amountOfWater => m_amountOfWater;

        private void Awake()
        {
            m_amountOfWaterText.text = "Воды: " + m_amountOfWater;
        }

        private void OnMouseDown()
        {
            var distance = Vector3.Distance(GameManager.Instance.m_playerTransform.position, transform.position);
            if (distance <= GameManager.Instance.maxDistanceToRefillWater.Value)
            {
                GameManager.Instance.IncreaseCurrentWaterAmount(m_amountOfWater);
                m_audioSource.PlayOneShot(m_getWaterSound);
            }
        }
    }
}