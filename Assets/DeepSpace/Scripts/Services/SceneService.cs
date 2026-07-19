using UnityEngine.SceneManagement;
using System.Collections;

namespace DeepSpace
{
    
    public class SceneService
    {
        public const string BOOTSTRAP_SCENE = "Bootstrap";
        public const string GAMEPLAY_SCENE = "Gameplay";
        
        public IEnumerator LoadGameplay()
        {
            yield return LoadScene(BOOTSTRAP_SCENE);
            yield return LoadScene(GAMEPLAY_SCENE);
        }

        private IEnumerator LoadScene(string sceneName)
        {
            yield return SceneManager.LoadSceneAsync(sceneName);
        }
    }
}