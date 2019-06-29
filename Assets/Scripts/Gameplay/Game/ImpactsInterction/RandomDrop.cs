using UnityEngine;

namespace Bomberman
{
    [RequireComponent(typeof(DamageReceiver))]
    public class RandomDrop : MonoBehaviour
    {
        [Range(0, 100)]
        public float chance;
        public GameObject[] prefabs;

        private void Awake()
        {
            DamageReceiver receiver = GetComponent<DamageReceiver>();
            receiver.OnDeath += OnObjectDestoyed;
        }

        private void OnObjectDestoyed()
        {
            TryDropItem();
        }

        private void TryDropItem()
        {
            if (prefabs.Length > 0 && GenericMethods.TryRandomChance(chance))
            {
                int r = Random.Range(0, prefabs.Length);
                Instantiate(prefabs[r], transform.position, Quaternion.identity);
            }
        }
    }
}
