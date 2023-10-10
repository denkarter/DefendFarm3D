using System;
using TMPro;
using UnityEngine;

namespace DefaultNamespace
{
    public class WinTimerScript: MonoBehaviour
    {
        [SerializeField] private float m_secondsToWin = 300;
        public TMP_Text timerText;
        private float timeRemaining;

        private void Awake()
        {
            timeRemaining = m_secondsToWin;
        }

        private void Update()
        {
            timeRemaining -= Time.deltaTime;
            
            if (timeRemaining < 0)
                timeRemaining = 0;

            int minutes = Mathf.FloorToInt(timeRemaining / 60);
            int seconds = Mathf.FloorToInt(timeRemaining % 60);
            
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
}