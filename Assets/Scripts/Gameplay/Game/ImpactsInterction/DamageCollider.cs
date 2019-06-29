using UnityEngine;

namespace Bomberman
{
    /// <summary>
    /// Try apply damage to collided object
    /// </summary>
    public class DamageCollider : MonoBehaviour
    {
        public float damage = 1;

        private void OnTriggerEnter(Collider other)
        {
            ApplyDamageTo(other.gameObject);
        }

        private void ApplyDamageTo(GameObject obj)
        {
            DamageReceiver receiver = obj.GetComponent<DamageReceiver>();
            if (receiver != null)
            {
                receiver.ApplyDamage(damage);
            }
        }
    }
}
