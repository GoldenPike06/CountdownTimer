using System;
using UnityEngine;

namespace GoldenPike.CountdownTimer.Scripts
{
    public class Timer : MonoBehaviour
    {
        public event Action OnTimerStart;
        public event Action OnTimerStop;
        public event Action OnTimerReset;
        public event Action OnTimerTick;
        public event Action OnTimerExpired;
        public event Action<AudioClip> OnTimerExpiredWithAudio;
        public event Action OnTimerPause;
        public event Action OnTimerResume;

        public float Duration;
        public bool Repeat;
        public TimerDisplayFormat DisplayFormat = TimerDisplayFormat.MinutesSeconds;
        public bool StartOnAwake = false;
        
        [SerializeField] private AudioClip clip;
        
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
                OnTimerExpiredWithAudio?.Invoke(clip);
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