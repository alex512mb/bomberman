namespace Bomberman.Bonus
{
    public class ImmortalityEffect : TempEffect
    {
        private bool immortalityBeforeEffect;
        private DamageReceiver receiver;


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
