using Game.UI;
using UnityEngine;
using Zenject;

namespace Game
{
    public class EntryPoint : MonoBehaviour
    {
        private LevelLoader _levelLoader;

        [Inject]
        public void Construct(LevelLoader levelLoader)
        {
            _levelLoader = levelLoader;
        }

        private void Start()
        {
            LoadLevel();
        }

        private void LoadLevel() => _levelLoader.LoadLevel(1);
    }
}