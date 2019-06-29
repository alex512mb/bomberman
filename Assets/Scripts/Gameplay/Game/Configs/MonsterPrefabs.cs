using Bomberman.LevelGeneration;
using Bomberman.Monster;
using System.Collections.Generic;

[System.Serializable]
public class CreaturePrefabs : PrefabsDefinition<CreatureID, MonsterAI>
{
    public MonsterAI prefabCreature_Ball;
    public MonsterAI prefabCreature_Ghost;
    public MonsterAI prefabCreature_Orange;
    public MonsterAI prefabCreature_Coin;

    protected override Dictionary<CreatureID, MonsterAI> CreateDictionaryPrefab()
    {
        Dictionary<CreatureID, MonsterAI> dict = new Dictionary<CreatureID, MonsterAI>
            {
                { CreatureID.Ball, prefabCreature_Ball },
                { CreatureID.Ghost, prefabCreature_Ghost },
                { CreatureID.Orange, prefabCreature_Orange },
                { CreatureID.Coin, prefabCreature_Coin }
            };
        return dict;
    }

}

