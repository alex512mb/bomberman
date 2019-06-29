using UnityEngine;


namespace Bomberman.Bonus
{
    public class SpeedUp : BonusTrigger
    {
        public float speedModCoeff;
        protected override void Apply(GameObject obj)
        {
            obj.SendMessage("ApplySpeedMod", speedModCoeff, SendMessageOptions.RequireReceiver);
        }
    }
}
