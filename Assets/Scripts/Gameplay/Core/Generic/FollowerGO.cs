using UnityEngine;

namespace Bomberman
{
    /// <summary>
    /// Smoothly follow a target(Transform)  
    /// </summary>
    public class FollowerGO : MonoBehaviour
    {
        public Transform targetFollow;
        public float smoothTime = 0.25f;
        public float maxSpeed = 3;

        private Transform m_transform;
        private Vector3 currentV;

        private Vector3 destinationPos => targetFollow.position;

        private void Awake()
        {
            m_transform = transform;
        }

        private void LateUpdate()
        {
            if (targetFollow == null)
            {
                enabled = false;
                return;
            }

            m_transform.position = Vector3.SmoothDamp(m_transform.position, destinationPos, ref currentV, smoothTime, maxSpeed);
        }
        public void SetTargetFollow(Transform _target)
        {
            targetFollow = _target;
            enabled = true;
        }

    }
}
