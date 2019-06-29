using UnityEngine;
using UnityEngine.SceneManagement;

namespace Bomberman
{
    /// <summary>
    /// Allow Loading different scenes
    /// </summary>
    public class LevelLoader : MonoBehaviour
    {
        private const string nameGameScene = "Game";


        public static void LoadNextLevel() 
        {
            Debug.LogWarning("For now LoadNextLevel not implemented, instead will execute ReloadCurrentLevel ");
            LoadGameScene();
        }
        public static void ReloadCurrentLevel()
        {
            LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        public static void LoadGameScene()
        {
            SceneManager.LoadScene(nameGameScene);
        }
        public static void LoadScene(int buildIndex)
        {
            SceneManager.LoadScene(buildIndex);
        }

    }
}
