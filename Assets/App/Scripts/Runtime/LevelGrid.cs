using Game.Enums;
using System.Collections.Generic;

namespace Game.Runtime
{
    [System.Serializable]
    public class LevelGrid
    {
        public GridFormType FormType;
        public List<BallType> BallTypes = new List<BallType>();
    }
}

