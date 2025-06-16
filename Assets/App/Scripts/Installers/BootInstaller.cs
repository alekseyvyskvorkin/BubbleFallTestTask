using UnityEngine;
using Zenject;

namespace Game.Installers
{
    public class BootInstaller : MonoInstaller
    {
        [SerializeField] private EntryPoint _entryPoint;

        public override void InstallBindings()
        {
            Container.Bind<EntryPoint>().FromInstance(_entryPoint).AsSingle().NonLazy();
        }
    }
}
