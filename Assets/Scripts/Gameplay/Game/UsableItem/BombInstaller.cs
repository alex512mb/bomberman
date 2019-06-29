using UnityEngine;

namespace Bomberman.UsableItem
{
    /// <summary>
    /// Create bombs with limit count instances in game
    /// </summary>
    public class BombInstaller : UsableItem
    {
        public GameObject prefabBomb;
        public int defaultBombLimit = 1;
        public int bombLimit;

        private int countBombInstances;
        private float additionalRadius;

        private void Awake()
        {
            bombLimit = defaultBombLimit;
        }

        private void TrySpawnBomb()
        {
            if (countBombInstances < bombLimit)
            {
                SpawnBomb();
            }
            else
            {
                Debug.Log("Player can't place a bomb because he is out of limitation, Here some sound will be nice");
            }
        }

        private void SpawnBomb()
        {
            GameObject instance = Instantiate(prefabBomb, transform.position.Snap(), Quaternion.identity);
            Bomb bomb = instance.GetComponent<Bomb>();
            bomb.radius += additionalRadius;
            countBombInstances++;

            //subscribe to event destroying created the bomb
            DestroyNotifier notifier = instance.GetComponent<DestroyNotifier>();
            if (notifier != null)
            {
                notifier.OnDestroyed += obj =>
            {
                countBombInstances--;
            };
            }
        }


        public override void Use()
        {
            TrySpawnBomb();
        }
        public void AddRadiusExplosion(float radius)
        {
            additionalRadius += radius;
        }
    }
}
