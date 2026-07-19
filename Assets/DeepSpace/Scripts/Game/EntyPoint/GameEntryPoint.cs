using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

namespace DeepSpace
{
    public class GameEntryPoint : System.IDisposable
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void StartApplication()
        {
            var gameEntryPoint = new GameEntryPoint();
            gameEntryPoint.Start();
        }
        
        private Coroutines _coroutine;
        public void Start()
        {
            _coroutine = new GameObject("[COROUTINES]").AddComponent<Coroutines>();
            Object.DontDestroyOnLoad(_coroutine);
            
            var sceneService = new SceneService();
            SceneManager.sceneLoaded += OnLoadScene;
            
            _coroutine.StartCoroutine(sceneService.LoadGameplay());
        }
        
        public void Dispose()
        {
            SceneManager.sceneLoaded -= OnLoadScene;
        }
        
        private void OnLoadScene(Scene scene, LoadSceneMode loadSceneMode)
        {
            var sceneName = scene.name;

            switch (sceneName)
            {
                case SceneService.GAMEPLAY_SCENE:
                    _coroutine.StartCoroutine(LoadGameplay());
                    return;
            }
        }

        private IEnumerator LoadGameplay()
        {
            var gameplayEntryPoint = Object.FindFirstObjectByType<GameplayEntryPoint>();
            
            yield return gameplayEntryPoint.Initialization();

            gameplayEntryPoint.Run();
        }
    }
}