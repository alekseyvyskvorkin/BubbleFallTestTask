using Game.Enums;
using NaughtyAttributes;
using UnityEngine;
using Zenject;
using System.Linq;

namespace Game.Runtime
{
    public class Ball : MonoBehaviour
    {
        [field: SerializeField] public BallType Type { get; private set; }

        [field: SerializeField] private BallMaterialPreset[] _materialPresets { get; set; }

        private MeshRenderer _renderer;

        [Inject]
        public void Initialize()
        {
            _renderer = GetComponent<MeshRenderer>();
        }

        [Button]
        public void SetRandomType()
        {
            Type = (BallType)Random.Range(0, (int)BallType.Red + 1);
            if (_renderer == null) _renderer = GetComponent<MeshRenderer>();
            _renderer.material = _materialPresets.Where(x => x.Type == Type).First().Material;
        }

        public void ChangeType(BallType type)
        {
            Type = type;
            if (_renderer == null) _renderer = GetComponent<MeshRenderer>();
            _renderer.material = _materialPresets.Where(x => x.Type == Type).First().Material;
        }
    }

    [System.Serializable]
    public class BallMaterialPreset
    {
        [field: SerializeField] public BallType Type { get; private set; }
        [field: SerializeField] public Material Material { get; private set; }
    }
}

