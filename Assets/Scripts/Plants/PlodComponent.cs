

using System.Collections;
using DG.Tweening;
using TMPro;
using UniRx;
using UnityEngine;

namespace DefaultNamespace.Plants
{
    public class PlodComponent: MonoBehaviour
    {
        [SerializeField] private CanvasGroup m_canvasGroup;
        [SerializeField] private GameObject m_canvas;
        [SerializeField] private Collider m_collider;
        [SerializeField] private MeshRenderer m_renderer;
        [SerializeField] private TMP_Text m_costCountText;

        private bool m_collected;

        private void OnEnable()
        {
            GameManager.Instance.plodSellingCost.Subscribe(x => m_costCountText.text = x.ToString());
        }
        
        private void OnCollisionEnter(Collision collision)
        {
            if (!m_collected && collision.gameObject.CompareTag("Player"))
            {
                m_canvasGroup.alpha = 1;
                transform.DOMove(transform.position + Vector3.up, 1);
                m_canvasGroup.DOFade(0, 1);
                
                GameManager.Instance.PlayCollectCoinSound();
                GameManager.Instance.m_coins.Value += GameManager.Instance.plodSellingCost.Value;

                m_collected = true;
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