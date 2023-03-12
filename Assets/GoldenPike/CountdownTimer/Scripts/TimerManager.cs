using System.Collections.Generic;
using UnityEngine;

namespace GoldenPike.CountdownTimer.Scripts
{
    /// <summary>
    /// Manages all timers in the scene. Attach this to a TimerManager GameObject in the scene.
    /// </summary>
    public class TimerManager : MonoBehaviour
    {
        public List<Timer> Timers = new List<Timer>();

        /// <summary>
        /// Creates a new timer as a child game object and adds it to the list of timers.
        /// </summary>
        public Timer CreateTimer(float duration, bool repeat = false, TimerDisplayFormat displayFormat = TimerDisplayFormat.MinutesSeconds,
            bool startOnAwake = false)
        {
            var go = new GameObject("Timer");
            go.transform.SetParent(transform);
            var timer = go.AddComponent<Timer>();
            timer.Duration = duration;
            timer.Repeat = repeat;
            timer.DisplayFormat = displayFormat;
            timer.StartOnAwake = startOnAwake;
            Timers.Add(timer);
            return timer;
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