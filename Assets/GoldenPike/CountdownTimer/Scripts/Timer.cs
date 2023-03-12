using System;
using UnityEngine;

namespace GoldenPike.CountdownTimer.Scripts
{
    /// <summary>
    /// Checks the state of the timer through events. Attach this to a Timer game object in the scene and serialize values in the inspector.
    /// </summary>
    public class Timer : MonoBehaviour
    {
        public event Action OnTimerStart;
        public event Action OnTimerStop;
        public event Action OnTimerReset;
        public event Action OnTimerTick;
        public event Action OnTimerExpired;
        public event Action OnTimerPause;
        public event Action OnTimerResume;
        public event Action OnCustomEvent;

        public float Duration;
        public bool Repeat;
        public TimerDisplayFormat DisplayFormat = TimerDisplayFormat.MinutesSeconds;
        public bool StartOnAwake = false;

        private float _remainingTime;
        private bool _isRunning = false;
        private bool _isPaused = false;

        private void Awake()
        {
            if (StartOnAwake)
                StartTimer();
        }

        private void Start()
        {
            _remainingTime = Duration;
        }

        private void Update()
        {
            CountDownTimer();
        }

        /// <summary>
        /// You can invoke the OnCustomEvent event here to trigger a custom event and use it in your own scripts.
        /// </summary>
        private void CountDownTimer()
        {
            if (!_isRunning || _isPaused) return;
            
            _remainingTime -= Time.deltaTime;

            if (_remainingTime <= 0.0f)
            {
                if (Repeat)
                    ResetTimer();
                else
                    StopTimer();

                OnTimerExpired?.Invoke();
            }
            else
                OnTimerTick?.Invoke();
        }

        public void StartTimer()
        {
            _isRunning = true;
            OnTimerStart?.Invoke();
        }

        public void StopTimer()
        {
            _isRunning = false;
            OnTimerStop?.Invoke();
        }

        private void ResetTimer()
        {
            _remainingTime = Duration;
            OnTimerReset?.Invoke();
        }

        public void PauseTimer()
        {
            _isPaused = true;
            OnTimerPause?.Invoke();
        }

        public void ResumeTimer()
        {
            _isPaused = false;
            OnTimerResume?.Invoke();
        }
        
        public void RestartTimer()
        {
            StopTimer();
            ResetTimer();
            StartTimer();
        }
        
        public float GetRemainingTime()
        {
            return _remainingTime;
        }
        
        public bool IsRunning()
        {
            return _isRunning;
        }

        private void OnValidate()
        {
            if (Duration < 0.0f)
                Duration = 0.0f;
        }

        private void OnDisable()
        {
            StopTimer();
        }
    }
    
    public enum TimerDisplayFormat
    {
        Seconds,
        MinutesSeconds,
        HoursMinutesSeconds
    }
}