using System.Collections;
using UnityEngine;

namespace DeepSpace
{
    public class GameplayEntryPoint : MonoBehaviour
    {
        private ServiceLocator _serviceLocator;
        public IEnumerator Initialization()
        {
            _serviceLocator = new ServiceLocator();
            _serviceLocator.RegisterSingletonService<IGameStateProvider>(factory => 
                new PlayerPrefsGameStateProvider());
            
            var gameStateProvider = _serviceLocator.GetService<IGameStateProvider>();
            var gameModel = gameStateProvider.LoadGameModel();
            
            _serviceLocator.RegisterService<IPlayerViewModel>(factory => new PlayerViewModel(gameModel.Player));

            var playerViewPrefab = Resources.Load<PlayerView>(GlobalConstants.PREFAB_PLAYER_VIEW);
            var playerView = Instantiate(playerViewPrefab);
            var playerViewModel = _serviceLocator.GetService<IPlayerViewModel>();
            playerView.Bind(playerViewModel);
            
            yield return null;
        }

        public void Run()
        {
            
        }

        private void OnDestroy()
        {
            _serviceLocator.Dispose();
        }
    }
}