namespace Bomberman.Monster
{
    /// <summary>
    /// This monster will be randomly walk around
    /// </summary>
    public class PassiveMonsterAI : MonsterAI
    {
        protected override void UpdateState()
        {
            if (monster.State == MonsterState.Idle)
            {
                monster.TryGoToRandomNeighbouring();
            }
        }
    }
}

