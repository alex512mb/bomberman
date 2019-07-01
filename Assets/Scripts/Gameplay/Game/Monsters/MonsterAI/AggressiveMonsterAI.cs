using UnityEngine;


namespace Bomberman.Monster
{
    /// <summary>
    /// This monster will be randomly walking around if no one target exists near
    /// </summary>
    public class AggressiveMonsterAI : MonsterAI
    {
        public ObjectSearcher m_Searcher;
        protected override void UpdateState()
        {
            if (monster.State == MonsterState.Idle)
            {
                GameObject target = m_Searcher.FindObject();
                bool succesGoToPlayer = target != null && monster.TryGoToTarget(target.transform);
                if (!succesGoToPlayer)
                {
                    monster.TryGoToRandomNeighbouring();
                }
            }
        }
    }
}
