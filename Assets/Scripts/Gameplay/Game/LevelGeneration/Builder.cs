using Bomberman.Configs;
using Bomberman.Monster;
using System;
using System.Collections.Generic;
using UnityEngine;


namespace Bomberman.LevelGeneration
{
    /// <summary>
    /// Determine how will Build gameplay level
    /// </summary>
    public class Builder
    {
        private GamePrefabs prefabs;
        private Level level;
        private Transform container;

        public Builder(GamePrefabs prefabs, Level level, Transform container)
        {
            this.prefabs = prefabs;
            this.level = level;
            this.container = container;
        }


        private TypeBehaviour[] CreateObjects<TypeEnum, TypeBehaviour>(GameObjectRecord<TypeEnum>[] records, PrefabsDefinition<TypeEnum, TypeBehaviour> prefabs, string containerName = "")
                                                                                                    where TypeBehaviour : MonoBehaviour where TypeEnum : Enum
        {
            string cName = string.IsNullOrEmpty(containerName) ? "Generated " + typeof(TypeEnum).ToString() : containerName;
            Transform containerObjects = new GameObject(cName).transform;
            containerObjects.parent = container;

            TypeBehaviour[] instances = new TypeBehaviour[records.Length];
            Dictionary<TypeEnum, Transform> dictSubContainers = new Dictionary<TypeEnum, Transform>();
            for (int i = 0; i < records.Length; i++)
            {
                GameObjectRecord<TypeEnum> objectRecord = records[i];

                //create container if not exist
                if (!dictSubContainers.ContainsKey(objectRecord.id))
                {
                    GameObject subContainer = new GameObject(objectRecord.id.ToString());
                    subContainer.transform.parent = containerObjects;
                    dictSubContainers.Add(objectRecord.id, subContainer.transform);
                }


                //instance object
                if (prefabs.Prefabs.TryGetValue(objectRecord.id, out TypeBehaviour prefab))
                {
                    if (prefab != null)
                    {
                        Vector3 pos = new Vector3(objectRecord.pos.x, 0, objectRecord.pos.y);
                        instances[i] = GameObject.Instantiate(prefab, pos, Quaternion.identity);
                        instances[i].transform.parent = dictSubContainers[objectRecord.id];
                    }
                    else
                    {
                        Debug.LogErrorFormat("Level Builder: Imposible to make an instance by reason - prefab with id {0} is NULL, you have to add a prefab in the inspector", objectRecord.id.ToString());
                    }
                }
                else
                {
                    Debug.LogErrorFormat("Level Builder: Imposible to make an instance by reason - Unknown id = {0}, you have to add the id into the prefabs Dictionary", objectRecord.id.ToString());
                }

            }
            return default;
        }
        public Block[] CreateBlocks()
        {
            Block[] blocks = CreateObjects(level.blocks, prefabs.blockPrefabs, "Generated Blocks");

            return blocks;
        }
        public MonsterAI[] CreateCreatures()
        {
            MonsterAI[] creatures = CreateObjects(level.creatures, prefabs.creaturePrefabs, "Spawned Creatures");

            return creatures;
        }


    }
}

