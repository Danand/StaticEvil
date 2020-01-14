using System;

namespace StaticEvil
{
    public sealed class Static<T> : IDisposable
        where T : class
    {
        private T value;

        void IDisposable.Dispose()
        {
            value = null;
        }

        private Static()
        {
            StaticDispatcher.DestroyOnCurrentSceneUnloaded(this);
        }

        public static implicit operator T(Static<T> wrapper)
        {
            return wrapper.value;
        }

        public static implicit operator Static<T>(T value)
        {
            return new Static<T> { value = value };
        }
    }
}