using UnityEngine;

namespace Bomberman
{
    /// <summary>
    ///  Represent behavior of the bomb 
    /// </summary>
    [DefaultExecutionOrder(-99)]
    public class Player : MonoBehaviour
    {
        public float speed = 3;
        private float speedCoeff = 1;

        private float currentSpeed => speed * speedCoeff;

        private float scaledSpeed => currentSpeed * Time.deltaTime;

        private Rigidbody m_body;

        public UsableItem.UsableItem handItem;
        private const ForceMode forceMode = ForceMode.VelocityChange;

        private void Awake()
        {
            m_body = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                handItem.Use();
            }
        }

        private void FixedUpdate()
        {
            //if key pressed then move the body
            if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            {
                AddForce(0, 0, -scaledSpeed);
            }

            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
            {
                AddForce(0, 0, scaledSpeed);
            }

            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                AddForce(-scaledSpeed, 0, 0);
            }

            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                AddForce(scaledSpeed, 0, 0);
            }
        }

        private void AddForce(Vector3 force)
        {
            AddForce(force.x, force.y, force.z);
        }

        private void AddForce(float x, float y, float z)
        {
            m_body.AddForce(x, y, z, forceMode);
        }


        public void ApplySpeedMod(float coeff)
        {
            speedCoeff = coeff;
        }
    }
}
