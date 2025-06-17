using Game.Runtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Creators
{
    public class EndSpawnPosition : MonoBehaviour
    {
        public bool IsFree => _colliders.Count == 0;
        private List<Collider> _colliders { get; set; } = new List<Collider>();

        private void OnTriggerEnter(Collider other)
        {
            if (!_colliders.Contains(other))
            {
                _colliders.Add(other);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (_colliders.Contains(other))
            {
                _colliders.Remove(other);
            }
        }
    }
}

