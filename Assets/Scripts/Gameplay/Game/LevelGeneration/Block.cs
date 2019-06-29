using System;
using System.Collections;
using System.Collections.Generic;
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
