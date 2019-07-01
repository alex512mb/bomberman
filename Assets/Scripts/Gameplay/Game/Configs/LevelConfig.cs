using Bomberman.LevelGeneration;
using UnityEngine;

namespace Bomberman.Configs
{
    [CreateAssetMenuAttribute(fileName = "LevelConfig", menuName = "Bomberman/LevelGeneration/LevelConfig")]
    public class LevelConfig : ScriptableObject
    {
        [Range(1, Mathf.Infinity)]
        public float timeLimit = 10;

        public LevelGenerator generator;
    }
}
