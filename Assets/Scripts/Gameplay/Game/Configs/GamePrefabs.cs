using UnityEngine;

namespace Bomberman.Configs
{
    [CreateAssetMenuAttribute(fileName = "Game prefabs", menuName = "Bomberman/LevelGeneration/GamePrefabs")]
    public class GamePrefabs : ScriptableObject
    {
        public BlockPrefabs blockPrefabs;
        public CreaturePrefabs creaturePrefabs;
    }
}
