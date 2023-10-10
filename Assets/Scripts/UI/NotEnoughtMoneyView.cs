using System;
using DefaultNamespace;
using DG.Tweening;
using UniRx;
using UnityEngine;

namespace UI
{
    public class NotEnoughtMoneyView: MonoBehaviour
    {
        [SerializeField] private CanvasGroup m_canvasGroup;

        private void Awake()
        {
            GameManager.Instance.showNotEnoughtText.Subscribe(_ => ShowNotEnoughtText());
        }

        private void ShowNotEnoughtText()
        {
            m_canvasGroup.alpha = 1;
            m_canvasGroup.DOFade(0, 2);
        }
    }
}