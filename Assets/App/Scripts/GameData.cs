using Game.Settings;
using System;

namespace Game.Data
{
    public class GameData
    {
        public int Score { get; private set; }

        public Action OnResetScore { get; set; }
        public Action<int> OnScoreChanged { get; set; }

        private ScoreConfig _scoreConfig;

        public GameData(MainConfig config)
        {
            _scoreConfig = config.ScoreConfig;
        }

        public void AddScore()
        {
            Score += _scoreConfig.ScorePerBall;
            OnScoreChanged?.Invoke(_scoreConfig.ScorePerBall);
        }

        public void ResetScore()
        {
            Score = 0;
            OnResetScore?.Invoke();
        }
    }
}

