using UnityEngine;

namespace Game.Settings
{
    [CreateAssetMenu(fileName = "MainConfig", menuName = "Data/MainConfig")]
    public class MainConfig : ScriptableObject
    {
        [field: SerializeField] public LevelConfig LevelConfig {  get; private set; }
        [field: SerializeField] public CreatableConfig CreatableConfig { get; private set; }
        [field: SerializeField] public ScoreConfig ScoreConfig { get; private set; }
    }
}

