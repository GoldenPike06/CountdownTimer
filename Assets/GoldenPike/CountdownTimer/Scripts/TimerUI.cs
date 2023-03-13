using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GoldenPike.CountdownTimer.Scripts
{
    /// <summary>
    /// UI component for displaying a timer. Attach this to a game object with a TextMeshProUGUI component.
    /// Serialize the timer you want to display in the inspector.
    /// You can also use the CreateTimer method from the TimerManager, then set the Timer property of this component.
    /// </summary>
    public class TimerUI : MonoBehaviour
    {
        [SerializeField] private Timer timer;

        public Timer Timer
        {
            get => timer;
            set => timer = value;
        }
        
        [SerializeField] private TMP_Text timeText;
        [SerializeField] private TMP_FontAsset font;
        [SerializeField] private Color textColor = Color.white;
        [SerializeField] private Slider progressBar;

        private void Start()
        {
            if (Timer == null)
                Debug.LogWarning("No timer assigned to TimerUI");
            
            timer.OnTimerTick += UpdateTimerUI;

            timeText.color = textColor;
            
            if (font != null)
                timeText.font = font;
            else
                Debug.LogWarning("No font assigned to TimerUI");

            if (progressBar != null)
                progressBar.maxValue = 1;
            else
                Debug.LogWarning("No progress bar assigned to TimerUI");
            
            string formattedTime = FormatTime(timer.Duration);
            timeText.text = formattedTime;

        }

        private void UpdateTimerUI()
        {
            string formattedTime = FormatTime(timer.GetRemainingTime());
            timeText.text = formattedTime;
            
            if (progressBar != null)
                progressBar.value = timer.GetRemainingTime() / timer.Duration;
        }
        
        private string FormatTime(float time)
        {
            TimeSpan timeSpan = TimeSpan.FromSeconds(time);
            switch (timer.DisplayFormat)
            {
                case TimerDisplayFormat.Seconds:
                    return $"{timeSpan.Seconds}";

                case TimerDisplayFormat.MinutesSeconds:
                    return $"{(int) timeSpan.TotalMinutes:00}:{timeSpan.Seconds:00}";

                case TimerDisplayFormat.HoursMinutesSeconds:
                    return $"{(int) timeSpan.TotalHours:00}:{timeSpan.Minutes:00}:{timeSpan.Seconds:00}";

                default:
                    return "";
            }
        }

        private void OnDisable()
        {
            timer.OnTimerTick -= UpdateTimerUI;
        }
    }
}