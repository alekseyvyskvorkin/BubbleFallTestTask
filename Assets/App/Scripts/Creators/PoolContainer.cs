using Game.Settings;
using UnityEngine;
using Zenject;

namespace Game.Creators
{
    public class PoolContainer : MonoBehaviour
    {
        private ParentsHolder _parentHolder;
        private ExecuteHandler _executeHandler;
        private Factory _factory;
        private CreatableConfig _creatableConfig;

        [Inject]
        public void Initialize(Factory factory,
            ExecuteHandler executeHandler,
            MainConfig config,
            ParentsHolder parentsHolder)
        {
            _executeHandler = executeHandler;
            _parentHolder = parentsHolder;
            _factory = factory;
            _creatableConfig = config.CreatableConfig;
        }
    }
}
