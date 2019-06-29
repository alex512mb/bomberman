using UnityEngine;

namespace Bomberman.Bonus
{
    public abstract class TempEffect : MonoBehaviour
    {
        public float timeRemain = 1;
        protected virtual void Start()
        {
            ApplyEffect();
        }

        protected virtual void Update()
        {
            timeRemain -= Time.deltaTime;
            if (timeRemain <= 0)
            {
                enabled = false;
                RemoveEffect();
            }
        }

        protected abstract void ApplyEffect();
        protected virtual void RemoveEffect()
        {
            Destroy(this);
        }
    }
}
