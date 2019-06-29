using System.Collections;
using UnityEngine;

namespace Bomberman
{
    /// <summary>
    /// Destroy himself after deley
    /// </summary>
    public class TimeDestructor : MonoBehaviour
    {
        public float lifeTime = 5;

        private IEnumerator Start()
        {
            yield return new WaitForSeconds(lifeTime);
            Destroy(gameObject);
        }
    }
}