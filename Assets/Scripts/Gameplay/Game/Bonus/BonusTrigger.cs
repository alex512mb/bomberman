using UnityEngine;

namespace Bomberman.Bonus
{
    /// <summary>
    /// Apply some effect to Triggered object
    /// </summary>
    public abstract class BonusTrigger : MonoBehaviour
    {
        public bool autoDestroy;

        private void OnTriggerEnter(Collider other)
        {
            Apply(other.gameObject);
            if (autoDestroy)
            {
                Destroy(gameObject);
            }
        }
        protected abstract void Apply(GameObject obj);

    }
    public enum BonusEffectID
    {
        AddBombExplosionRadius,
        AddBombsLimit,
        SpeedUp,
        Immortality,
    }
}
