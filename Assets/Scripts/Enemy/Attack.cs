using System;
using System.Linq;
using UnityEngine;

namespace Enemy
{
    [RequireComponent(typeof(Animator))]
    public class Attack: MonoBehaviour
    {
        public EnemyAnimator Animator;
        public float AttackCooldown = 3f;
        private float _currentAttackCoolDown;
        private bool _isAttacking;
        private int _layerMask;
        public float Cleavage = 0.5f;
        private Collider[] _hits = new Collider[1];
        private float EffectiveDistance = 0.5f;
        private bool _attackIsActive;

        private void Awake()
        {
            _layerMask = 1 << LayerMask.NameToLayer("Player");
        }

        private void Update()
        {
            Debug.Log(_currentAttackCoolDown);
            if (_currentAttackCoolDown > 0)
            {
                _currentAttackCoolDown -= Time.deltaTime;
            }
            if (_attackIsActive && !_isAttacking && _currentAttackCoolDown <= 0)
            {
                StartAttack();
                
            }
        }

        private void StartAttack()
        {
            Animator.PlayAttack();
            _isAttacking = true;
        }

        private void OnAttack()
        {
            if (Hit(out Collider hit))
            {
                
            }
        }

        private bool Hit(out Collider hit)
        {
            Vector3 startPoint = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z) + transform.forward*EffectiveDistance;
            int hitsCount = Physics.OverlapSphereNonAlloc(startPoint, Cleavage, _hits, _layerMask);
            hit = _hits.FirstOrDefault();
            return hitsCount > 0;
        }

        private void OnAttackEnded()
        {
            _currentAttackCoolDown = AttackCooldown;
            _isAttacking = false;
        }

        public void DisableAttack()
        {
            _attackIsActive = false;
        }

        public void EnableAttack()
        {
            _attackIsActive = true;
        }
    }
}