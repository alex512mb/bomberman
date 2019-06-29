using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public abstract class PrefabsDefinition<TypeEnum, TypeBehaviour> where TypeEnum : System.Enum where TypeBehaviour : MonoBehaviour
{
    private Dictionary<TypeEnum, TypeBehaviour> prefabs;
    public Dictionary<TypeEnum, TypeBehaviour> Prefabs
    {
        get
        {
            if (prefabs == null)
            {
                prefabs = CreateDictionaryPrefab();

                foreach (KeyValuePair<TypeEnum, TypeBehaviour> prefab in prefabs)
                {
                    Assert.IsNotNull(prefab.Value, "prefab: " + prefab.Key + " is null");
                }
            }

            return prefabs;
        }
    }

    protected abstract Dictionary<TypeEnum, TypeBehaviour> CreateDictionaryPrefab();
}
