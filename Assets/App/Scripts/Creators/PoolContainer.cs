using Cysharp.Threading.Tasks;
using Game.Data;
using Game.Runtime;
using Game.Settings;
using Game.UI;
using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Game.Creators
{
    public class PoolContainer : MonoBehaviour
    {
        private List<Ball> _activeBalls = new List<Ball>();
        private Queue<Ball> _balls = new Queue<Ball>();

        private ParentsHolder _parentHolder;
        private ExecuteHandler _executeHandler;
        private Factory _factory;
        private CreatableConfig _creatableConfig;
        private GameData _gameData;

        [Inject]
        public void Construct(Factory factory,
            ExecuteHandler executeHandler,
            MainConfig config,
            ParentsHolder parentsHolder,
            GameData gameData)
        {
            _executeHandler = executeHandler;
            _parentHolder = parentsHolder;
            _factory = factory;
            _creatableConfig = config.CreatableConfig;
            _gameData = gameData;
        }

        public Ball GetBall()
        {
            Ball ball = null;
            if (_balls.Count > 0)
            {
                ball = _balls.Dequeue();
            }
            else
            {
                ball = _factory.Create<Ball>(_creatableConfig.Ball);
                ball.OnReturnToPool += ReturnBall;
                ball.OnExplode += _gameData.AddScore;
                ball.OnFall += _gameData.AddScore;
            }

            _activeBalls.Add(ball);
            _executeHandler.AddToUpdate(ball);
            return ball;
        }

        private async void ReturnBall(Ball ball)
        {
            _activeBalls.Remove(ball);
            _executeHandler.RemoveFromUpdate(ball);
            await UniTask.Delay(1000);
            if (!_balls.Contains(ball)) _balls.Enqueue(ball);
        }
    }
}
