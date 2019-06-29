using UnityEngine;
using Bomberman.UsableItem;

namespace Bomberman.Bonus
{
    /// <summary>
    ///Increase the line length of bombs explosion 
    /// </summary>
    public class AddBombExplosionRadius : BonusTrigger
    {
        public float additionalRadius;
        protected override void Apply(GameObject obj)
        {
            var installer = obj.GetComponentInChildren<BombInstaller>();
            if (installer != null)
                installer.AddRadiusExplosion(additionalRadius);
        }
    }
}