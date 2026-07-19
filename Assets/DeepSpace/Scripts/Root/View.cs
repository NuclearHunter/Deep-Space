using UnityEngine;

namespace DeepSpace
{
    public abstract class View<T> : MonoBehaviour where T : IViewModel
    {
        protected T _viewModel;

        public void Bind(T viewModel)
        {
            _viewModel = viewModel;
        }

        private void Update()
        {
            _viewModel?.Update(Time.deltaTime);
        }

        private void FixedUpdate()
        {
            _viewModel?.PhysicsUpdate(Time.fixedDeltaTime);
        }
    }
}
