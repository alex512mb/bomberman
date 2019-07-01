using System.Collections.Generic;
using UnityEngine;

public static class GenericMethods
{
    public static void RandomizeArray<T1>(T1[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            T1 tmp = arr[i];
            int r = Random.Range(i, arr.Length);
            arr[i] = arr[r];
            arr[r] = tmp;
        }
    }
    public static void RandomizeList<T1>(List<T1> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            T1 tmp = list[i];
            int r = Random.Range(i, list.Count);
            list[i] = list[r];
            list[r] = tmp;
        }
    }
    public static bool TryRandomChance(float chance)
    {
        int randomValue = Random.Range(0, 101);
        return randomValue <= chance;
    }
}
