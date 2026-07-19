using UnityEngine;

namespace DeepSpace
{
    public interface IPlayerViewModel : IViewModel, IService
    {
        ReactiveProperty<Vector2> Position { get; }
    }
}