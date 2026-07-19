using UnityEngine;

namespace DeepSpace
{
    public class PlayerViewModel : BaseViewModel, IPlayerViewModel
    {
        public ReactiveProperty<Vector2> Position => _playerModel.Position;
        
        private readonly PlayerModel _playerModel;
        
        public PlayerViewModel(PlayerModel playerModel)
        {
            _playerModel = playerModel;
        }

        public void Dispose()
        {
            
        }
        
        public override void PhysicsUpdate(float deltaTime)
        {
            var direction = new Vector2(1, 0);
            _playerModel.Position.Value += direction * deltaTime * 5f;
        }
    }
}