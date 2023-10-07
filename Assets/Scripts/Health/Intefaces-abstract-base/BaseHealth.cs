using UnityEngine;

namespace Health
{
    public abstract class BaseHealth: MonoBehaviour, IDamagable, IRestorable
    {
        [SerializeField] protected int m_maxHealth;
        [SerializeField] protected int m_currentHealth;
        [SerializeField] protected HealthBar m_healthBar;
        [SerializeField] protected Animator m_animator;
        
        public virtual void GetDamage(int _damage)
        {
            m_currentHealth -= _damage;
            if (m_currentHealth < 0)
            {
                m_currentHealth = 0;
                m_animator.SetTrigger("Dead");
            }
            
            m_healthBar.SetBarValue(1f * m_currentHealth / m_maxHealth);
        }

        public virtual void RestoreHp(int _restoreHp)
        {
            m_currentHealth += _restoreHp;
            if (m_currentHealth > m_maxHealth)
                m_currentHealth = m_maxHealth;
            
            m_healthBar.SetBarValue(1f * m_currentHealth / m_maxHealth);
        }
    }
}