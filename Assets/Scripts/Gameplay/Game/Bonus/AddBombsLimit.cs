using UnityEngine;
using Bomberman.UsableItem;

namespace Bomberman.Bonus
{
    /// <summary>
    /// Increase limit of bombs which target can instantiate
    /// </summary>
    public class AddBombsLimit : BonusTrigger
    {
        public int count = 1;
        protected override void Apply(GameObject obj)
        {
            var installer = obj.GetComponentInChildren<BombInstaller>();
            if (installer != null)
                installer.bombLimit += count;
        }
    }
}
