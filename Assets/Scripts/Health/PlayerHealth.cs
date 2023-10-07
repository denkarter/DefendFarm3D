using Health;
using UnityEngine;

public class PlayerHealth: BaseHealth
{
    [SerializeField] private AudioClip m_hurtSound;
    [SerializeField] private AudioClip m_deadSound;
    
    public override void GetDamage(int _damage)
    {
        m_currentHealth -= _damage;
        if (m_currentHealth <= 0)
        {
            m_currentHealth = 0;
            m_healthBar.SetBarValue(1f * m_currentHealth / m_maxHealth);
            
            AudioSource.PlayClipAtPoint(m_deadSound, transform.position);
            m_animator.SetTrigger("Dead");
            
            return;
        }
            
        AudioSource.PlayClipAtPoint(m_hurtSound, transform.position);
        m_healthBar.SetBarValue(1f * m_currentHealth / m_maxHealth);
    }
}
