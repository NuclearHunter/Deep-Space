namespace DeepSpace
{
    public abstract class BaseViewModel : IViewModel
    {
        public virtual void Update(float deltaTime) { }

        public virtual void PhysicsUpdate(float deltaTime) { }
    }
}