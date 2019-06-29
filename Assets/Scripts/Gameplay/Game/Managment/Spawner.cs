using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bomberman
{
    /// <summary>
    /// It Component will spawn objects by time in free positions on the LevelGrid
    /// </summary>
    public class Spawner : MonoBehaviour
    {
        public LevelGrid levelGrid;
        public GameObject prefab;
        public int count;
        public float time;
        public bool autoStart;

        private List<Vector3> freePositions = new List<Vector3>();

        private void Start()
        {
            if (levelGrid == null)
            {
                throw new System.Exception("Need assign level grid in inspector");
            }

            if (autoStart)
            {
                StartSpawning();
            }


        }
        private IEnumerator ProgrammSpawn()
        {
            levelGrid.CalculateFreePositions();
            float durationOneStep = time / count;
            for (int i = 0; i < count; i++)
            {
                yield return new WaitForSeconds(durationOneStep);
                SpawnObj();
            }
        }
        private void SpawnObj()
        {
            Vector3 randomPos = levelGrid.GetRandomPos();
            Instantiate(prefab, randomPos, Quaternion.identity);
        }

        /// <summary>
        /// Create some Coin Monsters to Punishment the player
        /// </summary>
        public void StartSpawning()
        {
            StartCoroutine(ProgrammSpawn());
        }
    }
}
