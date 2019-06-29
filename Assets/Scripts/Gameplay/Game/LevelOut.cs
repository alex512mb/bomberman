using UnityEngine;

namespace Bomberman
{
    /// <summary>
    /// Load next level if was TriggerEnter
    /// </summary>
    public class LevelOut : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            LevelLoader.LoadNextLevel();
        }
    }
}
