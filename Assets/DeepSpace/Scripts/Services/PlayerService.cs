using UnityEngine;

namespace DeepSpace
{
    public class PlayerService : IService
    {
        private GameModel _gameModel;

        public PlayerService(IGameStateProvider gameStateProvider)
        {
            _gameModel = gameStateProvider.GameModel;
        }
        public void Dispose()
        {
            
        }
        
        public void Move(Vector2 direction, float deltaTime)
        {
            var playerModel = _gameModel.Player;
            float acceleration;
            if (playerModel.Speed.Value <= playerModel.MaxSpeed.Value*0.6f)
            {
                acceleration = playerModel.MaxSpeed.Value * 0.6f;
            }
            else if (playerModel.Speed.Value <= playerModel.MaxSpeed.Value * 0.8f)
            {
                acceleration = playerModel.MaxSpeed.Value * 0.2f;
            }
            else if (playerModel.Speed.Value <= playerModel.MaxSpeed.Value * 0.95f)
            {
                acceleration = playerModel.MaxSpeed.Value * 0.15f;
            }
            else
            {
                acceleration = playerModel.MaxSpeed.Value * 0.05f;
            }
           
         
            if (direction.magnitude >= 0.95f)
            {
                playerModel.Speed.Value += acceleration * deltaTime;
                
                if (playerModel.Speed.Value > playerModel.MaxSpeed.Value)
                {
                    playerModel.Speed.Value = playerModel.MaxSpeed.Value;
                }
                playerModel.LastDirection = direction;
            }
            else if (playerModel.Speed.Value > 0)
            {
                playerModel.Speed.Value -= deltaTime;
                if (playerModel.Speed.Value < 0)
                {
                    playerModel.Speed.Value = 0;
                }
            }
            
            
            playerModel.Position.Value += playerModel.LastDirection * playerModel.Speed.Value * deltaTime;
        }

        public void Roration(ModRotation Mod, float deltaTime)
        {
            var playerModel = _gameModel.Player;
            var newDirection = playerModel.LastDirection;
            var Gradus = 5;
            var Alfa = Mathf.PI/180*Gradus;
            if (Mod == ModRotation.Left)
            {
                newDirection.x = playerModel.LastDirection.x * Mathf.Cos(Alfa) - playerModel.LastDirection.y * Mathf.Sin(Alfa);
                newDirection.y = playerModel.LastDirection.x * Mathf.Sin(Alfa) + playerModel.LastDirection.y * Mathf.Cos(Alfa);
                playerModel.Rotation.Value = Gradus;
            }
            if (Mod == ModRotation.Right)
            {
                newDirection.x = playerModel.LastDirection.x * Mathf.Cos(Alfa) + playerModel.LastDirection.y * Mathf.Sin(Alfa);
                newDirection.y = - playerModel.LastDirection.x * Mathf.Sin(Alfa) + playerModel.LastDirection.y * Mathf.Cos(Alfa);
                playerModel.Rotation.Value = -Gradus;
            }
            newDirection.x /= newDirection.magnitude;
            newDirection.y /= newDirection.magnitude;

            playerModel.LastDirection = newDirection;
            Debug.Log(playerModel.LastDirection.magnitude);
        }
    }
    public enum ModRotation
    {
        Left,
        Right
    }
}
