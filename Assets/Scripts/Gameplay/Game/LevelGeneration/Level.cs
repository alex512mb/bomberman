using System;

namespace Bomberman.LevelGeneration
{
    /// <summary>
    /// Contains data to build gameplay level
    /// </summary>
    public struct Level
    {
        public BlockRecord[] blocks;
        public CreatureRecord[] creatures;
        public Level(BlockRecord[] blocks, CreatureRecord[] creatures)
        {
            this.blocks = new BlockRecord[blocks.Length];
            Array.Copy(blocks, this.blocks, blocks.Length);

            this.creatures = new CreatureRecord[creatures.Length];
            Array.Copy(creatures, this.creatures, creatures.Length);
        }
    }
}


