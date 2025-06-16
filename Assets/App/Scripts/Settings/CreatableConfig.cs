using Game.Runtime;
using UnityEngine;

namespace Game.Settings
{
    [CreateAssetMenu(fileName = "CreatableConfig", menuName = "Data/CreatableConfig")]
    public class CreatableConfig : ScriptableObject
    {
        [field: SerializeField] public Ball Ball { get; private set; }
    }
}

