using Game.Save;
using Game.Settings;
using Game.UI;
using UnityEngine;
using Zenject;

namespace Game.Installers
{
    public class GlobalInstaller : MonoInstaller
    {
        [SerializeField] private MainConfig _config;
        [SerializeField] private LevelLoader _levelLoader;

        public override void InstallBindings()
        {
            Container.Bind<LevelLoader>().FromInstance(_levelLoader).AsSingle().NonLazy();
            Container.Bind<MainConfig>().FromInstance(_config).AsSingle().NonLazy();
            Container.Bind<SaveSystem>().AsSingle().NonLazy();
        }
    }
}