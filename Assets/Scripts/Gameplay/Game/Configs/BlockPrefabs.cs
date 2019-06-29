using Bomberman.LevelGeneration;
using System.Collections.Generic;

namespace Bomberman.Configs
{
    [System.Serializable]
    public class BlockPrefabs : PrefabsDefinition<BlockID, Block>
    {
        public Block prefabUndestroyableTile;
        public Block prefabDestroyableTile;

        protected override Dictionary<BlockID, Block> CreateDictionaryPrefab()
        {
            Dictionary<BlockID, Block> dict = new Dictionary<BlockID, Block>
            {
                { BlockID.Undestroyable, prefabUndestroyableTile },
                { BlockID.Destroyable, prefabDestroyableTile }
            };
            return dict;
        }
    }
}
