namespace DeepSpace
{
    public interface IGameStateProvider : IService
    {
        GameModel GameModel { get; }
        
        GameModel LoadGameModel();
        
        bool SaveGameModel();
    }
}