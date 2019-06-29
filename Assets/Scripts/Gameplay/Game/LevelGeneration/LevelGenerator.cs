using System.Collections.Generic;
using UnityEngine;


namespace Bomberman.LevelGeneration
{
    [System.Serializable]
    public class LevelGenerator
    {
        [Range(3, 99)]
        public int height = 10;

        [Range(3, 99)]
        public int width = 20;

        [Range(1, 10)]
        public int widthBeetwenUndestroyableTiles = 1;
        [Range(1, 95)]
        public int chanceCreateDestroyableTile = 10;
        public CreaturesOption[] creatures;

        private const float oneTileSize = 1;

        public Level Generate()
        {
            //init
            List<BlockRecord> blockRecords = new List<BlockRecord>();
            List<CreatureRecord> creatureRecords = new List<CreatureRecord>();
            List<Vector2> listFreePositions = new List<Vector2>();
            Vector2[] containerFreePositions;
            List<CreatureID> allCreatureIDs = new List<CreatureID>();

            //Convert creatures to list
            for (int i1 = 0; i1 < creatures.Length; i1++)
            {
                for (int i2 = 0; i2 < creatures[i1].count; i2++)
                {
                    allCreatureIDs.Add(creatures[i1].id);
                }
            }


            //Make Upper Border
            for (int i = 0; i < width + 2; i++)
            {
                blockRecords.Add(new BlockRecord(BlockID.Undestroyable, oneTileSize * i, (height + 1) * oneTileSize));
            }

            //Make Bottom Border
            for (int i = 0; i < width + 2; i++)
            {
                blockRecords.Add(new BlockRecord(BlockID.Undestroyable, oneTileSize * i, 0));
            }

            //Make Left Border
            for (int i = 0; i < height; i++)
            {
                blockRecords.Add(new BlockRecord(BlockID.Undestroyable, 0, oneTileSize * (i + 1)));
            }

            //Make Right Border
            for (int i = 0; i < height; i++)
            {
                blockRecords.Add(new BlockRecord(BlockID.Undestroyable, (width + 1) * oneTileSize, oneTileSize * (i + 1)));
            }


            //Make Undestroyable Layer
            int counterH = 0, counterV = 0;
            for (int x = 0; x < width; x++)
            {
                for (int z = 0; z < height; z++)
                {
                    if (counterH % (widthBeetwenUndestroyableTiles + 1) == 0 && counterV % (widthBeetwenUndestroyableTiles + 1) == 0)
                    {
                        counterH = counterV = 0;
                        blockRecords.Add(new BlockRecord(BlockID.Undestroyable, GetPositionByIndex(x, z)));
                    }
                    else
                    {
                        listFreePositions.Add(GetPositionByIndex(x, z));
                    }

                    counterV++;
                }
                counterH++;
            }


            //randomly to mix the list of free positions
            GenericMethods.RandomizeList(listFreePositions);


            //make a warning about overcounting amount of creatures
            if (allCreatureIDs.Count > listFreePositions.Count)
            {
                Debug.LogWarning(string.Format("Not enough space for all CustomTiles. Needed {0} free spaces, but exist only {1} free spaces", allCreatureIDs.Count, listFreePositions.Count));
            }


            //Add creatures into the level
            containerFreePositions = listFreePositions.ToArray();
            int countCustomTiles = Mathf.Min(allCreatureIDs.Count, listFreePositions.Count);
            for (int i = 0; i < countCustomTiles; i++)
            {
                listFreePositions.Remove(containerFreePositions[i]);
                creatureRecords.Add(new CreatureRecord(allCreatureIDs[i], containerFreePositions[i]));
            }


            //Make Destroyable Layer
            containerFreePositions = listFreePositions.ToArray();
            for (int i = 0; i < containerFreePositions.Length; i++)
            {
                if (GenericMethods.TryRandomChance(chanceCreateDestroyableTile))
                {
                    listFreePositions.Remove(containerFreePositions[i]);
                    blockRecords.Add(new BlockRecord(BlockID.Destroyable, containerFreePositions[i]));
                }
            }

            return new Level(blockRecords.ToArray(), creatureRecords.ToArray());
        }

        private Vector2 GetPositionByIndex(int indexX, int indexY)
        {
            float x = (indexX + 1) * oneTileSize;
            float y = (indexY + 1) * oneTileSize;
            return new Vector2(x, y);
        }


        [System.Serializable]
        public class CreaturesOption
        {
            public CreatureID id;
            public int count;
        }
    }
}
