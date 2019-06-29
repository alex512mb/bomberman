using UnityEngine;


namespace Bomberman.Monster
{
    public abstract class MonsterAI : MonoBehaviour
    {
        public float updatesPerSecond = 5;
        public MonsterController monster;


        private float deleyUpdate;
        private float timeLastUpdate = -999;

        protected virtual void Awake()
        {
            deleyUpdate = 1f / updatesPerSecond;
        }
        protected virtual void Update()
        {
            if (Time.time > timeLastUpdate + deleyUpdate)
            {
                timeLastUpdate = Time.time;
                UpdateState();
            }
        }
        protected abstract void UpdateState();
    }
}
