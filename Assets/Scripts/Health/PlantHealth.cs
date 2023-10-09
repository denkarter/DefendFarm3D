using System;
using DefaultNamespace;
using Health;
using UnityEngine;

public class PlantHealth: BaseHealth
{
    [SerializeField] private AudioSource m_audioSource;
    [SerializeField] private AudioClip m_healByWaterSound;
    
    private void OnMouseDown()
    {
        var distance = Vector3.Distance(GameManager.Instance.m_playerTransform.position, transform.position);
        
        if (GameManager.Instance.currentWaterAmount.Value < GameManager.Instance.decreaseWaterPerPour.Value)
            return;
        
        if (distance <= GameManager.Instance.maxDistanceToRestorePlantHp.Value)
        {
            m_audioSource.PlayOneShot(m_healByWaterSound);
            RestoreHp(GameManager.Instance.restoreHpPerHit.Value);
            GameManager.Instance.DecreaseCurrentWaterAmount(GameManager.Instance.decreaseWaterPerPour.Value);
        }
    }
}
