using System;
using DefaultNamespace;
using UnityEngine;

namespace Prefabs.UI
{
    public class Billboard: MonoBehaviour
    {
        private Transform m_transform;

        private void Awake()
        {
            m_transform = GameManager.Instance.m_playerTransform;
        }

        private void LateUpdate()
        {
            transform.LookAt(m_transform);
        }
    }
}