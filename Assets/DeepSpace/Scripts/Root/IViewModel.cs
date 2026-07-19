namespace DeepSpace
{
    public interface IViewModel
    {
        void Update(float deltaTime);
        
        void PhysicsUpdate(float deltaTime);
    }
}
