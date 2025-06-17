using UnityEngine;

namespace Game.Settings
{
    [CreateAssetMenu(fileName = "ScoreConfig", menuName = "Data/ScoreConfig")]
    public class ScoreConfig : ScriptableObject
    {
        [field: SerializeField] public int ScorePerBall { get; set; } = 10;
    }

    
}

