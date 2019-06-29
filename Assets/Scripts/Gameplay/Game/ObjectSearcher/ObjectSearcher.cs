using UnityEngine;

namespace Bomberman
{
    /// <summary>
    /// Incapsulate searching some GameObject
    /// </summary>
    public abstract class ObjectSearcher : MonoBehaviour
    {
        public abstract GameObject FindObject();
    }
}
