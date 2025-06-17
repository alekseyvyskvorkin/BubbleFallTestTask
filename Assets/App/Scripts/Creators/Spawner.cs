using Game.Runtime;
using Game.Save;
using Game.Settings;
using System;
using System.Collections;
using UnityEngine;
using Zenject;

namespace Game.Creators
{
    public class Spawner : MonoBehaviour
    {
        [field: SerializeField] private int _gridSizeX { get; set; } = 14;
        [field: SerializeField] private float _offsetZ { get; set; } = 0.9f;
        [field: SerializeField] private EndSpawnPosition _endSpawnPosition { get; set; }

        private Level _currentLevel => _levelConfig.Levels[_saveSystem.SaveData.LevelId];
        private LevelGrid _levelGrid => _currentLevel.LevelGrid[_currentGridIndex];

        private SaveSystem _saveSystem;
        private LevelConfig _levelConfig;
        private PoolContainer _pool;

        private int _currentGridIndex;
        private int _currentSpawnIndex;

        [Inject]
        public void Construct(MainConfig config, SaveSystem saveSystem, PoolContainer poolContainer)
        {
            _levelConfig = config.LevelConfig;
            _saveSystem = saveSystem;
            _pool = poolContainer;
        }

        private void Start()
        {
            StartSpawn();
        }

        public void StartSpawn()
        {
            StartCoroutine(Spawn());
        }

        private IEnumerator Spawn()
        {
            _currentGridIndex = 0;
            _currentSpawnIndex = 0;
            float offsetZ = 0;
            float offsetX = 0;
            Vector3 spawnPosition = Vector3.zero;
            int spawnCount = _gridSizeX;

            for (int i = 0; i < (int)_endSpawnPosition.transform.position.z; i++)
            {
                offsetZ = (i * _offsetZ) + _currentLevel.StartSpawnPositionZ;
                spawnPosition = new Vector3(offsetX, 0, offsetZ);
                CreateBalls(ref spawnCount, spawnPosition, ref offsetX, ref offsetZ);
            }
            yield return null;
            while (true)
            {
                if (_endSpawnPosition.IsFree)
                {
                    offsetZ += _offsetZ;
                    spawnPosition = new Vector3(offsetX, 0, spawnPosition.z + _offsetZ);
                    CreateBalls(ref spawnCount, spawnPosition, ref  offsetX, ref offsetZ);
                }
                yield return null;
            }
        }

        private void CreateBalls(ref int count, Vector3 spawnPosition, ref float offsetX, ref float offsetZ)
        {           
            for (int x = 0; x < count; x++)
            {
                var ball = _pool.GetBall();
                ball.transform.SetPositionAndRotation(spawnPosition, Quaternion.identity);
                ball.ChangeType(_levelGrid.BallTypes[_currentSpawnIndex]);
                spawnPosition = new Vector3(x + offsetX + 1, 0, offsetZ);
                _currentSpawnIndex++;
                if (_currentSpawnIndex >= _levelGrid.BallTypes.Count)
                {
                    _currentSpawnIndex = 0;
                    _currentGridIndex++;
                    if (_currentGridIndex >= _currentLevel.LevelGrid.Length) _currentGridIndex = 0;
                }
            }
            if (count == _gridSizeX)
            {
                count = _gridSizeX - 1;
                offsetX = 0.5f;               
            }
            else
            {
                count = _gridSizeX;
                offsetX = 0;
            }
        }
    }
}