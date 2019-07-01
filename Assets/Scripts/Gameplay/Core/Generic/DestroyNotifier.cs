using UnityEngine;

namespace Bomberman
{
    /// <summary>
    /// Notifying about destroying the attached object
    /// </summary>
    public class DestroyNotifier : MonoBehaviour
    {
        public event System.Action<GameObject> OnDestroyed;

        private void OnDestroy()
        {
            if (OnDestroyed != null)
            {
                OnDestroyed(gameObject);
            }
        }
    }
}
