using System.Collections.Generic;
using UnityEngine;

namespace ColorBallsPuzzle.Gameplay
{
    [CreateAssetMenu]
    public class SeralizableBallColorSettings : ScriptableObject
    {
        public List<Color> Colors;
    }
}