using UnityEngine;

namespace Bomberman.LevelGeneration
{
    /// <summary>
    /// Record about one creature
    /// </summary>
    public class CreatureRecord : GameObjectRecord<CreatureID>
    {
        public CreatureRecord(CreatureID _id, Vector2 _pos)
        {
            pos = _pos;
            id = _id;
        }
    }



    /// <summary>
    /// Identity type of creature
    /// </summary>
    public enum CreatureID
    {
        Ball,
        Ghost,
        Orange,
        Coin,
    }
}
