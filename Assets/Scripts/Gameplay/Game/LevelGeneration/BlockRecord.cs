using UnityEngine;

namespace Bomberman.LevelGeneration
{
    /// <summary>
    /// Record about one block of game level
    /// </summary>
    public class BlockRecord : GameObjectRecord<BlockID>
    {
        public BlockRecord(BlockID _id, Vector2 _pos)
        {
            pos = _pos;
            id = _id;
        }
        public BlockRecord(BlockID _id, float posX, float posY)
        {
            pos = new Vector2(posX, posY);
            id = _id;
        }
    }
    /// <summary>
    /// Identity type of level block
    /// </summary>
    public enum BlockID
    {
        Undestroyable,
        Destroyable,
    }

}

