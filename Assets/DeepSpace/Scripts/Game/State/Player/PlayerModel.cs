using UnityEngine;

namespace DeepSpace
{
    public class PlayerModel
    {
        public ReactiveProperty<Vector2> Position { get; private set; }
        
        public PlayerState OriginState { get; private set; }
        
        public PlayerModel(PlayerState originState)
        {
            OriginState = originState;
            
            Position =  new ReactiveProperty<Vector2>(originState.position);
            Position.UpdateValueEvent += OnPlayerUpdatePosition;
        }

        private void OnPlayerUpdatePosition(Vector2 newPosition)
        {
            OriginState.position = newPosition;
        }
    }
}