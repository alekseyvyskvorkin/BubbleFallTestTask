using Cysharp.Threading.Tasks;
using Game.Enums;
using Game.Runtime;
using Game.Settings;
using NaughtyAttributes;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game.Creators
{
    public class LevelCreator : MonoBehaviour
    {
        [field: SerializeField] private LevelConfig _levelConfig { get; set; }
        [field: SerializeField] private CreatableConfig _creatableConfig { get; set; }
        [field: SerializeField] private GridFormType _gridFormType { get; set; }

        [field: SerializeField] public int _levelLenght { get; set; } = 100;
        [field: SerializeField] public int _gridSizeX { get; set; } = 14;
        [field: SerializeField] public float _offsetZ { get; set; } = 0.9f;

        [Button]
        public async void CreateBallGrid()
        {
            List<Transform> childs = new List<Transform>();
            foreach (Transform child in transform) childs.Add(child);
            foreach (Transform child in childs) DestroyImmediate(child.gameObject);
            await UniTask.Yield();
            for (int i = 0; i < _levelLenght; i++)
            {
                float offsetZ = 0f;
                float offsetX = 0f;
                int spawnCount = _gridSizeX;
                if (i % 2 != 0 && i != 0 || i == 1)
                {
                    spawnCount--;
                    offsetX += 0.5f;
                }
                Vector3 spawnPosition = new Vector3(offsetX, 0, i * _offsetZ);
                for (int x = 0; x < spawnCount; x++)
                {
                    var ball = Instantiate(_creatableConfig.Ball, spawnPosition, Quaternion.identity, transform);
                    ball.Initialize();
                    ball.SetRandomType();
                    spawnPosition = new Vector3(x + offsetX + 1, 0, i * _offsetZ);
                }
                offsetZ += _offsetZ;
            }
        }

        [Button]
        public void SetLevelGrid()
        {
            var levelGrid = _levelConfig.AllGrids.Where(x => x.FormType == _gridFormType).First();
            levelGrid.BallTypes.Clear();
            foreach (Transform child in transform)
            {
                levelGrid.BallTypes.Add(child.GetComponent<Ball>().Type);
            }
        }
    }
}
