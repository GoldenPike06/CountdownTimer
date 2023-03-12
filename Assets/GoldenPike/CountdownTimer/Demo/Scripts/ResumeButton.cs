using UnityEngine;
using UnityEngine.UI;
using GoldenPike.CountdownTimer.Scripts;

namespace GoldenPike.CountdownTimer.Demo.Scripts
{
    public class ResumeButton : MonoBehaviour
    {
        [SerializeField] private TimerManager timerManager;
        [SerializeField] private Timer timer;

        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(ResumeTimers);
            //button.onClick.AddListener(ResumeTimer);
        }

        private void ResumeTimer()
        {
            //timerManager.ResumeTimer(timerManager.Timers[0]);
            timerManager.ResumeTimer(timer);
        }

        private void ResumeTimers()
        {
            foreach (var timerObj in timerManager.Timers)
            {
                timerManager.ResumeTimer(timerObj);
            }
        }
    }
}
