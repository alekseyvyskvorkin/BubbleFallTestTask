using Game.Enums;
using Game.Runtime;
using UnityEngine;

namespace Game.Settings
{
    [CreateAssetMenu(fileName = "LevelConfig", menuName = "Data/LevelConfig")]
    public class LevelConfig : ScriptableObject
    {
        [field: SerializeField] public Level[] Levels { get; private set; }

        [field: SerializeField] public LevelGrid[] AllGrids { get; set; }
    }

    [System.Serializable]
    public class Level
    {
        [field: SerializeField] public LevelGrid[] LevelGrid { get; private set; }       
    }

    
}

