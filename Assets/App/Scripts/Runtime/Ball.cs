using Game.Enums;
using NaughtyAttributes;
using UnityEngine;
using Zenject;
using System.Linq;
using System;
using Game.Interfaces;

namespace Game.Runtime
{
    public class Ball : MonoBehaviour, IExecutable
    {
        public Action<Ball> OnReturnToPool { get; set; }
        public Action OnFall { get; set; }
        public Action OnExplode { get; set; }

        [field: SerializeField] public BallType Type { get; private set; }

        [field: SerializeField] private BallMaterialPreset[] _materialPresets { get; set; }

        private MeshRenderer _renderer;

        [Inject]
        public void Construct()
        {
            _renderer = GetComponent<MeshRenderer>();
        }

        [Button]
        public void SetRandomType()
        {
            Type = (BallType)UnityEngine.Random.Range(0, (int)BallType.Red + 1);
#if UNITY_EDITOR
            if (_renderer == null) _renderer = GetComponent<MeshRenderer>();
#endif
            _renderer.material = _materialPresets.Where(x => x.Type == Type).First().Material;
        }

        public void ChangeType(BallType type)
        {
            Type = type;
#if UNITY_EDITOR
            if (_renderer == null) _renderer = GetComponent<MeshRenderer>();
#endif
            _renderer.material = _materialPresets.Where(x => x.Type == Type).First().Material;
        }

        public void Execute()
        {
           
        }
    }

    [System.Serializable]
    public class BallMaterialPreset
    {
        [field: SerializeField] public BallType Type { get; private set; }
        [field: SerializeField] public Material Material { get; private set; }
    }
}

