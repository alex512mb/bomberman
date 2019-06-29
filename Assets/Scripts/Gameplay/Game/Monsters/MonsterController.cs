using UnityEngine;
using UnityEngine.AI;


namespace Bomberman.Monster
{
    /// <summary>
    /// Allow to control a monster by some commands
    /// </summary>
    public class MonsterController : MonoBehaviour
    {
        public LayerMask maskObstacles;
        public float distanceDetectTarget = 3;
        private MonsterState state;
        public MonsterState State { get => state; set => state = value; }

        private NavMeshAgent m_navAgent;
        private Transform m_target;
        private Transform m_transform;

        private void Awake()
        {
            m_transform = transform;
            m_navAgent = GetComponent<NavMeshAgent>();
        }

        private void Update()
        {
            if (State == MonsterState.Move && m_navAgent.remainingDistance <= m_navAgent.stoppingDistance + m_navAgent.radius)
            {
                StopMoving();
            }
            else if (State == MonsterState.Follow)
            {
                if (m_target == null)
                {
                    State = MonsterState.Idle;
                    return;
                }
                if (GetDistanceToTarget() <= distanceDetectTarget)
                {
                    SetDestination(m_target.position);
                }
                else
                {
                    StopMoving();
                }
            }
        }

        private void StopMoving()
        {
            State = MonsterState.Idle;
            m_navAgent.isStopped = true;
        }

        private void SetDestination(Vector3 pos)
        {
            m_navAgent.SetDestination(pos);
            m_navAgent.isStopped = false;
        }

        private float GetDistanceToTarget()
        {
            return Vector3.Distance(m_target.position, m_transform.position);
        }

        private bool TryGetNeighbouringFreePlace(out Vector3 freePos)
        {
            freePos = Vector3.zero;
            Vector3 currentPos = new Vector3(m_transform.position.x, 0, m_transform.position.z).Snap();
            Vector3 leftPos = currentPos + Vector3.left;
            Vector3 rightPos = currentPos + Vector3.right;
            Vector3 forwardPos = currentPos + Vector3.forward;
            Vector3 backwardPos = currentPos + Vector3.back;
            Vector3[] neighbouringPositions = new Vector3[4] { leftPos, rightPos, forwardPos, backwardPos };

            //mixup positions
            GenericMethods.RandomizeArray(neighbouringPositions);

            for (int i = 0; i < neighbouringPositions.Length; i++)
            {
                if (CheackAvailablePos(neighbouringPositions[i]))
                {
                    freePos = neighbouringPositions[i];
                    return true;
                }
            }
            return false;

        }

        private bool CheackAvailablePos(Vector3 pos)
        {
            return !Physics.CheckSphere(pos, 0.45f, maskObstacles);
        }

        public bool TryGoToRandomNeighbouring()
        {
            if (TryGetNeighbouringFreePlace(out Vector3 freePos))
            {
                State = MonsterState.Move;
                SetDestination(freePos);
                return true;
            }
            return false;
        }
        public bool TryGoToTarget(Transform potencealTarget)
        {
            float distaceToTarget = Vector3.Distance(m_transform.position, potencealTarget.position);
            Ray ray = new Ray(m_transform.position, potencealTarget.position - m_transform.position);
            if (distaceToTarget <= distanceDetectTarget && !Physics.Raycast(ray, distaceToTarget, maskObstacles) && !Physics.Raycast(ray, distaceToTarget, maskObstacles))
            {
                m_target = potencealTarget;
                State = MonsterState.Follow;
                SetDestination(m_target.position);
                return true;
            }

            return false;
        }
    }
    public enum MonsterState
    {
        Idle = 0,
        Move = 1,
        Follow = 2,
    }
}