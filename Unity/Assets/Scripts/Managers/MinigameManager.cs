using System;
using LD52.Abstractions;
using LD52.Controllers;
using LD52.ScriptableObjects;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace LD52.Managers
{
    public class MinigameManager : SceneSingleton<MinigameManager>
    {
        private ushort _timeRemaining = 30;
        private ushort _currentTime = 0;
        private ushort _basketsCollected = 0;
        private bool _gameOver = false;

        private Coroutine _timerRoutine;
        [SerializeField] private TextMeshProUGUI _timerText, _basketText, _gameOverText;
        [SerializeField] private GameObject _gameOverWindow;
        [SerializeField] private Button _gameOverReturnButton;
        [SerializeField] private AudioSource _musicAudioSource;
        
        [SerializeField] private Crop[] _crops;
        public Crop[] Crops => _crops;

        private void ResetUI()
        {
            _timerText.text = "0:30";
        }

        protected override void InitSingletonInstance()
        {
            ResetUI();
            _musicAudioSource.volume = SettingsManager.Instance.Settings.MusicVolume;
            EventController.OnBasketCollected += OnBasketCollected;
            EventController.OnGameOver += OnGameOver;
            _gameOverReturnButton.onClick.AddListener(() =>
            {
                AudioManager.Instance.Play("click");
                SceneManager.LoadScene("Menu");
            });
            _timerRoutine = StartCoroutine(CoroutineTemplate.DelayAndFireLoopRoutine(1, () =>
            {
                if (_gameOver || _timeRemaining == 0) return;
                _timeRemaining--;
                _currentTime++;
                if (_timeRemaining == 0)
                {
                    EventController.GameOver();
                }
                _timerText.text = _timeRemaining < 60
                    ? $"0:{_timeRemaining:00}"
                    : $"{_timeRemaining / 60}:{_timeRemaining % 60:00}";
            }));
        }

        private void OnDestroy()
        {
            EventController.OnBasketCollected -= OnBasketCollected;
            EventController.OnGameOver -= OnGameOver;
        }

        private void OnBasketCollected()
        {
            _basketsCollected++;
            _basketText.text = _basketsCollected.ToString();

            _timeRemaining += 3;
            _timerText.text = _timeRemaining < 60
                ? $"0:{_timeRemaining:00}"
                : $"{_timeRemaining / 60}:{_timeRemaining % 60:00}";
        }

        private void OnGameOver()
        {
            AudioManager.Instance.Play("outoftime");
            _gameOver = true;
            StopCoroutine(_timerRoutine);
            var timeText = _currentTime < 60
                ? $"0:{_currentTime:00}"
                : $"{_currentTime / 60}:{_currentTime % 60:00}";
            _gameOverText.text = $"<b>Baskets Collected:</b> {_basketsCollected}{Environment.NewLine}<b>Time Played:</b> {timeText}";
            _gameOverWindow.SetActive(true);
        }
    }
}
