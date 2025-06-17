using Game.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;
using DG.Tweening;
using NaughtyAttributes;

namespace Game.UI
{
    public class ScoreText : MonoBehaviour
    {
        [field: SerializeField] private TMP_Text _scoreText {  get; set; }
        [field: SerializeField] public float _animationDuration { get; set; } = 0.2f;
        [field: SerializeField] public Vector3 _punchScale { get; set; } = Vector3.one * 0.15f;

        private GameData _gameData;

        [Inject]
        public void Construct(GameData gameData)
        {
            _gameData = gameData;
            _gameData.OnScoreChanged += AddScore;
            _gameData.OnResetScore += ResetScore;
        }

        private void AddScore(int count)
        {
            _scoreText.text = count.ToString();
            Animate();
        }

        [Button]
        private void ResetScore()
        {
            _scoreText.text = "0";
            Animate();
        }

        private void Animate()
        {
            _scoreText.transform.DOKill();
            _scoreText.transform.localScale = Vector3.one;
            _scoreText.transform.DOPunchScale(_punchScale, _animationDuration, 1, 0).SetUpdate(true);
        }
    }
}

