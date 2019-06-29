namespace Bomberman.Bonus
{
    public class ImmortalityEffect : TempEffect
    {
        bool immortalityBeforeEffect;
        DamageReceiver receiver;


        protected override void ApplyEffect()
        {
            receiver = gameObject.GetComponent<DamageReceiver>();
            if (receiver != null)
            {
                immortalityBeforeEffect = receiver.Immortality;
                receiver.Immortality = true;
            }
        }
        protected override void RemoveEffect()
        {
            receiver.Immortality = immortalityBeforeEffect;
            base.RemoveEffect();
        }
    }
}
