using System.Collections.Generic;
using UnityEngine;
using System;
using Game.Interfaces;

namespace Game
{
    public class ExecuteHandler : MonoBehaviour
    {
        private Dictionary<Type, List<IExecutable>> _executables = new Dictionary<Type, List<IExecutable>>();
        private Dictionary<Type, List<IExecutable>> _lateUpdateExecutables = new Dictionary<Type, List<IExecutable>>();

        private void Update()
        {
            foreach (var executables in _executables.Values)
            {
                foreach (var executable in executables)
                {
                    executable.Execute();
                }
            }
        }

        private void LateUpdate()
        {
            foreach (var executables in _lateUpdateExecutables.Values)
            {
                foreach (var executable in executables)
                {
                    executable.Execute();
                }
            }
        }

        public void AddToUpdate(IExecutable executable)
        {

            if (_executables.TryGetValue(executable.GetType(), out var executables))
            {
                if (!executables.Contains(executable))
                {
                    executables.Add(executable);
                }
            }
            else if (!_executables.ContainsKey(executable.GetType()))
            {
                var list = new List<IExecutable>() { executable };
                _executables.Add(executable.GetType(), list);
            }
        }

        public void RemoveFromUpdate(IExecutable executable)
        {
            if (_executables.ContainsKey(executable.GetType()) == false) return;
            if (_executables[executable.GetType()].Contains(executable) == false) return;
            _executables[executable.GetType()].Remove(executable);
        }

        public void AddToLateUpdate(IExecutable executable)
        {
            if (_lateUpdateExecutables.TryGetValue(executable.GetType(), out var executables))
            {
                if (!executables.Contains(executable))
                {
                    executables.Add(executable);
                }

            }
            else if (!_lateUpdateExecutables.ContainsKey(executable.GetType()))
            {
                var list = new List<IExecutable>() { executable };
                _lateUpdateExecutables.Add(executable.GetType(), list);
            }
        }

        public void RemoveFromLateUpdate(IExecutable executable)
        {
            if (_lateUpdateExecutables.ContainsKey(executable.GetType()) == false) return;
            if (_lateUpdateExecutables[executable.GetType()].Contains(executable) == false) return;
            _lateUpdateExecutables[executable.GetType()].Remove(executable);
        }
    }
}
