using System;
using Zenject;
using UnityEngine;
using Game.Creators;
using Game.Inputs;

namespace Game.Installers
{
    public class MainSceneInstaller : MonoInstaller
    {
        [field: SerializeField] private PoolContainer _pool { get; set; }
        [field: SerializeField] private Spawner _spawner { get; set; }
        [field: SerializeField] private ParentsHolder _parentHolder { get; set; }
        [field: SerializeField] private InputHandler _input { get; set; }
        [field: SerializeField] private ExecuteHandler _executeHandler { get; set; }


        public override void InstallBindings()
        {
            Container.Bind<PoolContainer>().FromInstance(_pool).AsSingle().NonLazy();
            Container.Bind<Spawner>().FromInstance(_spawner).AsSingle().NonLazy();
            Container.Bind<ParentsHolder>().FromInstance(_parentHolder).AsSingle().NonLazy();
            Container.Bind<InputHandler>().FromInstance(_input).AsSingle().NonLazy();
            Container.Bind<ExecuteHandler>().FromInstance(_executeHandler).AsSingle().NonLazy();

            Container.Bind<Factory>().AsSingle().NonLazy();
        }
    }
}
