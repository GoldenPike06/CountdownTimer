using UnityEngine;
using UnityEngine.UI;
using GoldenPike.CountdownTimer.Scripts;

namespace GoldenPike.CountdownTimer.Demo.Scripts
{
    public class PauseButton : MonoBehaviour
    {
        [SerializeField] private TimerManager timerManager;
        [SerializeField] private Timer timer;

        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(PauseTimers);
            //button.onClick.AddListener(PauseTimer);
        }

        private void PauseTimer()
        {
            //timerManager.PauseTimer(timerManager.Timers[0]);
            timerManager.PauseTimer(timer);
        }

        private void PauseTimers()
        {
            foreach (var timerObj in timerManager.Timers)
            {
                timerManager.PauseTimer(timerObj);
            }
        }
    }
}