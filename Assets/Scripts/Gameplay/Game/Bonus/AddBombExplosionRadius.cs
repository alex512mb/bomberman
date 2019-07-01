using Bomberman.UsableItem;
using UnityEngine;

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
            BombInstaller installer = obj.GetComponentInChildren<BombInstaller>();
            if (installer != null)
            {
                installer.AddRadiusExplosion(additionalRadius);
            }
        }
    }
}