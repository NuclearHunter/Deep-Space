using UnityEngine;

namespace DeepSpace
{
    public class PlayerViewModel : BaseViewModel, IPlayerViewModel
    {
        public ReactiveProperty<Vector2> Position => _playerModel.Position;
        public ReactiveProperty<float> Rotation => _playerModel.Rotation;
        public ReactiveProperty<float> Speed => _playerModel.Speed;
        
        private readonly PlayerModel _playerModel;
        private readonly PlayerService _playerService;
        
        public PlayerViewModel(IGameStateProvider gameStateProvider, PlayerService playerService)
        {
            _playerModel = gameStateProvider.GameModel.Player;
            _playerService = playerService;
        }

        public void Dispose()
        {
            
        }
        
        public override void PhysicsUpdate(float deltaTime)
        {
           _playerService.Move(_playerModel.LastDirection, deltaTime);
           _playerService.Roration(ModRotation.Right, deltaTime);
        }
    }
}