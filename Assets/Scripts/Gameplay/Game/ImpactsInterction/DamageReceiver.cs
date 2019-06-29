using System;
using UnityEngine;

namespace Bomberman
{
    /// <summary>
    /// Receive and handle damage
    /// </summary>
    public class DamageReceiver : MonoBehaviour
    {
        public bool Immortality;
        public bool autoDestroy = true;
        public float hp;
        public event Action OnDeath;

        private float currentHP;

        private void Awake()
        {
            currentHP = hp;
        }
        public void ApplyDamage(float damage)
        {
            if (Immortality)
            {
                return;
            }

            if (currentHP > 0)
            {
                currentHP -= damage;

                if (currentHP <= 0 && OnDeath != null)
                {
                    OnDeath();
                }

                if (autoDestroy)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
