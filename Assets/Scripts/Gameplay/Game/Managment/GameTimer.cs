using System.Collections;
using UnityEngine;

namespace Bomberman
{
    /// <summary>
    /// Timer will counting second from -duration to zero
    /// </summary>
    public class GameTimer : MonoBehaviour
    {
        public float duration;
        public event System.Action<float> OnChangeTimeRemain;
        public event System.Action OnTimeOver;

        private float timePassed => Time.timeSinceLevelLoad;
        private float timeRemain => Mathf.Clamp(duration - timePassed, 0, Mathf.Infinity);


        private void Start()
        {
            StartCoroutine(ProgrammUpdateTime());
        }

        private IEnumerator ProgrammUpdateTime()
        {
            while (true)
            {
                if (timeRemain <= 0)
                {
                    SafeCallOnTimeOver();
                    break;
                }
                else
                {
                    SafeCallOnChangeTimeRemain();
                }

                yield return new WaitForSeconds(1);
            }
        }

        private void SafeCallOnChangeTimeRemain()
        {
            if (OnChangeTimeRemain != null)
            {
                OnChangeTimeRemain(timeRemain);
            }
        }

        private void SafeCallOnTimeOver()
        {
            if (OnTimeOver != null)
            {
                OnTimeOver();
            }
        }


        public void SetDuration(float time)
        {
            duration = time;
        }
    }
}


