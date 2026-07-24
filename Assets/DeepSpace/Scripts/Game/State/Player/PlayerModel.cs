using UnityEngine;

namespace DeepSpace
{
    public class PlayerModel
    {
        public ReactiveProperty<float> Speed { get; private set; } = new (0);
        public Vector2 LastDirection = new Vector2(0, 1);
        public ReactiveProperty<float> MaxSpeed { get; private set; }
        public ReactiveProperty<Vector2> Position { get; private set; }
        public ReactiveProperty<float> Rotation { get; private set; } = new(0);
        
        public PlayerState OriginState { get; private set; }
        
        public PlayerModel(PlayerState originState)
        {
            
            OriginState = originState;

            MaxSpeed = new ReactiveProperty<float>(originState.maxSpeed);
            MaxSpeed.UpdateValueEvent += OnPlayerUpdateMaxSpeed;
            Position =  new ReactiveProperty<Vector2>(originState.position);
            Position.UpdateValueEvent += OnPlayerUpdatePosition;
        }

        private void OnPlayerUpdateMaxSpeed(float newMaxSpeed)
        {
            OriginState.maxSpeed = newMaxSpeed;
        }
        private void OnPlayerUpdatePosition(Vector2 newPosition)
        {
            OriginState.position = newPosition;
        }
    }
}