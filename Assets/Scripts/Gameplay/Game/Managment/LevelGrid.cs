using System.Collections.Generic;
using UnityEngine;

namespace Bomberman
{
    /// <summary>
    /// Allow to get free pos on the game level
    /// </summary>
    public class LevelGrid : MonoBehaviour
    {
        public Vector3 size;
        public LayerMask maskObstacles;

        private List<Vector3> freePositions = new List<Vector3>();

        public void CalculateFreePositions()
        {
            freePositions.Clear();
            int countHorizontalTiles = (int)size.x;
            int countVerticalTiles = (int)size.z;
            for (int x = 0; x < countHorizontalTiles; x++)
            {
                for (int z = 0; z < countVerticalTiles; z++)
                {
                    Vector3 pos = transform.position + new Vector3(x, 0, z);
                    if (CheackAvailablePos(pos))
                    {
                        freePositions.Add(pos);
                    }
                }
            }
        }
        public Vector3 GetRandomPos()
        {
            if (freePositions.Count > 0)
            {
                int r = Random.Range(0, freePositions.Count);
                return freePositions[r];
            }
            else
            {
                return transform.position;
            }
        }

        private bool CheackAvailablePos(Vector3 pos)
        {
            return !Physics.CheckSphere(pos, 0.45f, maskObstacles);
        }
    }
}
