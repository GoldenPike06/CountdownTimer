using System.Collections.Generic;
using UnityEngine;

namespace GoldenPike.CountdownTimer.Scripts
{
    public class TimerManager : MonoBehaviour
    {
        public List<Timer> Timers = new List<Timer>();
        
        public Timer CreateTimer(float duration, bool repeat = false, TimerDisplayFormat displayFormat = TimerDisplayFormat.MinutesSeconds,
            bool startOnAwake = false, AudioClip clip = null)
        {
            var go = new GameObject("Timer");
            go.transform.SetParent(transform);
            var timer = go.AddComponent<Timer>();
            timer.Duration = duration;
            timer.Repeat = repeat;
            timer.DisplayFormat = displayFormat;
            timer.StartOnAwake = startOnAwake;
            timer.OnTimerExpiredWithAudio += PlaySoundEffect;
            Timers.Add(timer);
            return timer;
        }

        private void PlaySoundEffect(AudioClip clip)
        {
            if (clip == null) return;
            AudioSource.PlayClipAtPoint(clip, Vector3.zero);
        }
        
        #region Control Individual Timers

        public void StartTimer(Timer timer)
        {
            timer.StartTimer();
        }

        public void StopTimer(Timer timer)
        {
            timer.StopTimer();
        }
        
        public void PauseTimer(Timer timer)
        {
            timer.PauseTimer();
        }

        public void ResumeTimer(Timer timer)
        {
            timer.ResumeTimer();
        }

        public void RestartTimer(Timer timer)
        {
            timer.RestartTimer();
        }

        #endregion

        #region Control All Timers

        public void StartAllTimers()
        {
            foreach (var timer in Timers)
            {
                timer.StartTimer();
            }
        }

        public void StopAllTimers()
        {
            foreach (var timer in Timers)
            {
                timer.StopTimer();
            }
        }

        public void RestartAllTimers()
        {
            foreach (var timer in Timers)
            {
                timer.RestartTimer();
            }
        }

        public void PauseAllTimers()
        {
            foreach (var timer in Timers)
            {
                timer.PauseTimer();
            }
        }
        
        public void ResumeAllTimers()
        {
            foreach (var timer in Timers)
            {
                timer.ResumeTimer();
            }
        }

        #endregion
    }
}