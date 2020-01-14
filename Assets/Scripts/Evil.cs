using System;

namespace StaticEvil
{
    public sealed class Evil<T> : IDisposable
        where T : class
    {
        public T Value { get; private set; }

        void IDisposable.Dispose()
        {
            Value = null;
        }

        private Evil()
        {
            StaticDispatcher.DestroyOnCurrentSceneUnloaded(this);
        }

        public static implicit operator Evil<T>(T value)
        {
            return new Evil<T> { Value = value };
        }
    }
}