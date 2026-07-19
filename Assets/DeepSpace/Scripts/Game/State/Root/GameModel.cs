namespace DeepSpace
{
    public class GameModel
    {
        public PlayerModel Player { get; set; }
        
        public GameState OriginState { get; private set; }
        
        public GameModel(GameState gameState)
        {
            OriginState = gameState;
            
            Player = new PlayerModel(gameState.player);
        }
    }
}