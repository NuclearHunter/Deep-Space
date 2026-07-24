using System;
using System.Xml.Serialization;
using UnityEngine;

namespace DeepSpace
{
    public class PlayerView : View<IPlayerViewModel>
    {
        [SerializeField] private Transform _playerTransform;
        [SerializeField] private float currentSpeed;
        protected override void OnBind()
        {
            _viewModel.Position.UpdateValueEvent += OnUpdatePosition;
            _viewModel.Speed.UpdateValueEvent += OnUpdateSpeed;
            _viewModel.Rotation.UpdateValueEvent += OnUpdateRotation;
        }

        public void OnDestroy()
        {
            _viewModel.Position.UpdateValueEvent -= OnUpdatePosition;
            _viewModel.Speed.UpdateValueEvent -= OnUpdateSpeed;
            _viewModel.Rotation.UpdateValueEvent -= OnUpdateRotation;
        }

        private void OnUpdateRotation(float newRotation)
        {
            _playerTransform.Rotate(new Vector3(0, 0, newRotation));
        }

        private void OnUpdateSpeed(float newSpeed)
        {
            currentSpeed = newSpeed;
        }
        private void OnUpdatePosition(Vector2 newPosition)
        {
            _playerTransform.position = newPosition;
        }
    }
}