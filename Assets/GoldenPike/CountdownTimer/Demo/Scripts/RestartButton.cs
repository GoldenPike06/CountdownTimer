using UnityEngine;
using UnityEngine.UI;
using GoldenPike.CountdownTimer.Scripts;

namespace GoldenPike.CountdownTimer.Demo.Scripts
{
    public class RestartButton : MonoBehaviour
    {
        [SerializeField] private TimerManager timerManager;
        [SerializeField] private Timer timer;

        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(RestartTimers);
            //button.onClick.AddListener(RestartTimer);
        }

        private void RestartTimer()
        {
            //timerManager.RestartTimer(timerManager.Timers[0]);
            timerManager.RestartTimer(timer);
        }

        private void RestartTimers()
        {
            timerManager.RestartAllTimers();
        }
    }
}