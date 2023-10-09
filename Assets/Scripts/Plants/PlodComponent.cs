using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;

namespace DefaultNamespace.Plants
{
    public class PlodComponent: MonoBehaviour
    {
        [SerializeField] private int m_coinsPurchase;
        [SerializeField] private CanvasGroup m_canvasGroup;
        [SerializeField] private GameObject m_canvas;
        [SerializeField] private Collider m_collider;
        [SerializeField] private MeshRenderer m_renderer;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                transform.DOMove(transform.position + Vector3.up, 1);
                m_canvasGroup.DOFade(0, 1);
                
                GameManager.Instance.PlayCollectCoinSound();
                GameManager.Instance.m_coins.Value += m_coinsPurchase;

                DisableObject();
            }
        }

        private void LateUpdate()
        {
            m_canvas.transform.position = transform.position + Vector3.up;
            m_canvas.transform.LookAt(Camera.main.transform);
        }

        private void DisableObject()
        {
            m_collider.enabled = false;
            m_renderer.enabled = false;
            StartCoroutine("DeleteObject");
        }
        
        private IEnumerator DeleteObject( )
        {
            yield return new WaitForSeconds(1);
            Destroy(gameObject);
        }
    }
}