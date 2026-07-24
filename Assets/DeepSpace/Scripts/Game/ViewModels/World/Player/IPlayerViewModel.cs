using UnityEngine;

namespace DeepSpace
{
    public interface IPlayerViewModel : IViewModel, IService
    {
        ReactiveProperty<Vector2> Position { get; }
        ReactiveProperty<float> Speed { get; }
        public ReactiveProperty<float> Rotation { get; }
    }
}