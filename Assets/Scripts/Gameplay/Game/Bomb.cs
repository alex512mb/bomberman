using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bomberman
{
    /// <summary>
    /// Represent behavior of a bomb 
    /// </summary>
    public class Bomb : MonoBehaviour
    {
        public float radius = 1;
        public float damage = 1;
        public float deley = 3;
        public LayerMask maskTargets;
        public LayerMask maskObstacles;
        public LineRenderer prefabLineExplosion;

        private float distanceLine => radius - 0.5f;

        private IEnumerator Start()
        {
            yield return new WaitForSeconds(deley);
            Explode();
        }

        private void Explode()
        {
            line[] lines = CalculateLinesOfExplosion();
            for (int i = 0; i < lines.Length; i++)
            {
                //aplly some damage to target
                RaycastHit[] hits = Physics.RaycastAll(lines[i].posA, lines[i].posB - lines[i].posA, lines[i].length, maskTargets);
                for (int p = 0; p < hits.Length; p++)
                {
                    ApplyDamageTo(hits[p].collider.gameObject);
                }

                //visualize the effet of Explosion
                LineRenderer lineInstance = Instantiate(prefabLineExplosion);
                lineInstance.SetPosition(0, lines[i].posA);
                lineInstance.SetPosition(1, lines[i].posB);

            }

            Destroy(gameObject);
        }

        private line[] CalculateLinesOfExplosion()
        {
            //calculate end points of lines
            Vector3 currentPos = transform.position.Snap();
            Vector3 leftEdgePosition = CalculateEndOfLine(distanceLine, currentPos, Vector3.left);
            Vector3 rightEdgePosition = CalculateEndOfLine(distanceLine, currentPos, Vector3.right);
            Vector3 forwardEdgePosition = CalculateEndOfLine(distanceLine, currentPos, Vector3.forward);
            Vector3 backEdgePosition = CalculateEndOfLine(distanceLine, currentPos, Vector3.back);

            List<line> lines = new List<line>();
            if (leftEdgePosition != rightEdgePosition)
            {
                lines.Add(new line(leftEdgePosition, rightEdgePosition));
            }

            if (forwardEdgePosition != backEdgePosition)
            {
                lines.Add(new line(forwardEdgePosition, backEdgePosition));
            }

            return lines.ToArray();
        }

        private Vector3 CalculateEndOfLine(float maxLength, Vector3 startPos, Vector3 direction)
        {
            Ray ray = new Ray(startPos, direction);
            RaycastHit hit = new RaycastHit();
            if (Physics.Raycast(ray, out hit, maxLength, maskObstacles))
            {
                ApplyDamageTo(hit.collider.gameObject);
                return hit.point;
            }
            else
            {
                return startPos + maxLength * direction;
            }
        }

        private void ApplyDamageTo(GameObject obj)
        {
            DamageReceiver receiver = obj.GetComponent<DamageReceiver>();
            if (receiver != null)
            {
                receiver.ApplyDamage(damage);
            }
        }

        private class line
        {
            public line(Vector3 a, Vector3 b)
            {
                posA = a;
                posB = b;
            }
            public float length => Vector3.Distance(posA, posB);
            public Vector3 posA;
            public Vector3 posB;
        }
    }
}
