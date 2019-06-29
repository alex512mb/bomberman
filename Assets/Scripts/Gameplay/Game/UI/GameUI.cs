using UnityEngine;
using UnityEngine.UI;

namespace Bomberman
{
    /// <summary>
    /// Just visualized game information for the player
    /// </summary>
    public class GameUI : MonoBehaviour
    {
        public Text txtTimer;
        private const string strTime = "Time";

        public void UpdateTime(float seconds)
        {
            txtTimer.text = string.Format("{0} = {1}", strTime, StringTools.BuildTimeString(seconds));
        }
    }

}

