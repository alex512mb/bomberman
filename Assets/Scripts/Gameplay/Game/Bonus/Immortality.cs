using UnityEngine;


namespace Bomberman.Bonus
{
    /// <summary>
    /// Applyed Immortality to taget
    /// </summary>
    public class Immortality : BonusTrigger
    {
        public float duration;
        protected override void Apply(GameObject obj)
        {
            ImmortalityEffect effect = obj.GetComponent<ImmortalityEffect>();
            if (effect == null)
            {
                effect = obj.AddComponent<ImmortalityEffect>();
                effect.timeRemain = duration;
            }
            else
            {
                effect.timeRemain += duration;
            }
        }
    }
}
