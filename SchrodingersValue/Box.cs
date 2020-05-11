using System;

namespace SchrodingersValue
{
    public struct Box<T>
    {
        Box(T value, bool hasValue) => (this.value, this.hasValue) = (value, hasValue);

        public static Box<T> Empty
        {
            get
            {
                return new Box<T>(default(T), false);
            }
        }

        T value { get; }

        bool hasValue { get; }

        public static Box<T> Create(T value)
        {
            if (value == null)
            {
                return Box<T>.Empty;
            }

            return new Box<T>(value, true);
        }

        public static implicit operator Box<T>(T value)
        {
            if (value == null)
            {
                return Box<T>.Empty;
            }

            return new Box<T>(value, true);
        }

        public void Open(Action<T> isAlive, Action isDead)
        {
            if (this.hasValue)
            {
                isAlive(this.value);
                return;
            }

            isDead();
        }

        public T TryOpen()
        {
            if (!this.hasValue) { throw new InvalidOperationException("Box is empty, it does not contain a value."); }

            return this.value;
        }
    }
}
