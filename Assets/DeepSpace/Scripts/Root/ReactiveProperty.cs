using System;

namespace DeepSpace
{
    public class ReactiveProperty<T>
    {
        public event Action<T> UpdateValueEvent;
        public T Value
        {
            get => _value;
            
            set
            {
                _value = value;
                UpdateValueEvent?.Invoke(value);
            }
        }

        private T _value;

        public ReactiveProperty(T value)
        {
            _value = value;
        }
    }
}