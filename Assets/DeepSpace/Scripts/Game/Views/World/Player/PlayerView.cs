using UnityEngine;

namespace DeepSpace
{
    public class PlayerView : View<IPlayerViewModel>
    {
        [SerializeField] private Transform _playerTransform;
        protected override void OnBind()
        {
            _viewModel.Position.UpdateValueEvent += OnUpdatePosition;
        }

        public void OnDestroy()
        {
            _viewModel.Position.UpdateValueEvent -= OnUpdatePosition;
        }

        private void OnUpdatePosition(Vector2 newPosition)
        {
            _playerTransform.position = newPosition;
        }
    }
}