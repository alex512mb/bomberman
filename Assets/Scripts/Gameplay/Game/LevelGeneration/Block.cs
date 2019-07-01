using System;
using UnityEngine;

namespace Bomberman.LevelGeneration
{
    public class Block : MonoBehaviour
    {
        public event Action onDestoyed;

        private void OnDestroy()
        {
            onDestoyed?.Invoke();
        }
    }
}
