using UnityEngine;
using GoldenPike.CountdownTimer.Scripts;

namespace GoldenPike.CountdownTimer.Demo.Scripts
{
    public class TimerTest : MonoBehaviour
    {
        [SerializeField] private TimerManager timerManager;
        [SerializeField] private TimerUI timerUI;

        private void Start()
        {
            var timer = timerManager.CreateTimer(5555, false, TimerDisplayFormat.HoursMinutesSeconds, true, 3);
            timerUI.Timer = timer;
            timer.StartTimer();
        }
    }
}