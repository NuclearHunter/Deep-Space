namespace DeepSpace
{
    public class PlayerPrefsGameStateProvider : IGameStateProvider
    {
        public GameModel GameModel { get; private set; }
        
        public void Dispose()
        {
            
        }
        
        public GameModel LoadGameModel()
        {
            var gameState = new GameState()
            {
                player = new PlayerState()
                {
                    maxSpeed = 10
                }
            };
            
            GameModel = new GameModel(gameState);
            
            return GameModel;
        }

        public bool SaveGameModel()
        {
            return true;
        }
        
    }
}