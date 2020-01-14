using System;

namespace StaticEvil
{
    public sealed class Static<T> : IDisposable
        where T : class
    {
        public T Value { get; private set; }

        void IDisposable.Dispose()
        {
            Value = null;
        }

        private Static()
        {
            StaticDispatcher.DestroyOnCurrentSceneUnloaded(this);
        }

        public static implicit operator Static<T>(T value)
        {
            return new Static<T> { Value = value };
        }
    }
}