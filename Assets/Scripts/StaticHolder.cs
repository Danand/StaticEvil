using System;
using System.Collections.Generic;

using UnityEngine;

namespace StaticEvil
{
    internal class StaticHolder : MonoBehaviour
    {
        private readonly List<IDisposable> staticWrappers = new List<IDisposable>();

        void OnDestroy()
        {
            foreach (var staticWrapper in staticWrappers)
                staticWrapper.Dispose();
        }

        public void Add<T>(Evil<T> wrapper)
            where T : class
        {
            staticWrappers.Add(wrapper);
        }
    }
}