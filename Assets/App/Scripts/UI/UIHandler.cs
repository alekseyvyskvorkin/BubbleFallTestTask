using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Game.UI
{
    public class UIHandler : MonoBehaviour
    {
        [field: SerializeField] private GameObject _startPlayPanel { get; set; }
        [field: SerializeField] private Button _startPlayButton { get; set; }

        private GameStateService _gameStateService;

        [Inject]
        public void Construct(GameStateService gameStateService)
        {
            _gameStateService = gameStateService;
        }

        private void Start()
        {
            _startPlayButton.onClick.AddListener(StartPlay);
        }

        private void StartPlay()
        {
            _startPlayPanel.SetActive(false);
            _gameStateService.OnStartPlay?.Invoke();
        }
    }
}

