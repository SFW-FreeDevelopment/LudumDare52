using LD52.Abstractions;
using TMPro;
using UnityEngine;

namespace LD52.Managers
{
    public class MinigameManager : SceneSingleton<MinigameManager>
    {
        private ushort _currentTime = 0;

        private Coroutine _timerRoutine;
        [SerializeField] private TextMeshProUGUI _timerText;

        private void ResetUI()
        {
            _timerText.text = "0:00";
        }
        
        protected override void InitSingletonInstance()
        {
            ResetUI();
            _timerRoutine = StartCoroutine(CoroutineTemplate.DelayAndFireLoopRoutine(1, () =>
            {
                _currentTime++;
                _timerText.text = _currentTime < 60
                    ? $"0:{_currentTime:00}"
                    : $"{_currentTime / 60}:{_currentTime % 60:00}";
            }));
        }

        private void GameOver()
        {
            StopCoroutine(_timerRoutine);
        }
    }
}
