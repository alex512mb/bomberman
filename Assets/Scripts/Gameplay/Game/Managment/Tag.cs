using UnityEngine;

namespace Bomberman
{
    /// <summary>
    /// Represent a tag for TagCollector
    /// </summary>
    [RequireComponent(typeof(DamageReceiver))]
    public class Tag : MonoBehaviour
    {
        private DamageReceiver damageReceiver;
        private void Awake()
        {
            damageReceiver = GetComponent<DamageReceiver>();
            damageReceiver.OnDeath += OnObjectDestroed;
            TagCollector.RegistryTag(gameObject.tag, this);
        }

        private void OnObjectDestroed()
        {
            damageReceiver.OnDeath -= OnObjectDestroed;
            TagCollector.UnregistryTag(gameObject.tag, this);
        }

    }
}