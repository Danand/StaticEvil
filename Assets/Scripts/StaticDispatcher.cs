using UnityEngine;

namespace StaticEvil
{
    internal static class StaticDispatcher
    {
        private static readonly StaticHolder staticHolder;

        static StaticDispatcher()
        {
            if (Application.isPlaying)
            {
                staticHolder = new GameObject().AddComponent<StaticHolder>();
                staticHolder.hideFlags = HideFlags.HideInHierarchy;
            }
        }

        public static void DestroyOnCurrentSceneUnloaded<T>(Static<T> wrapper)
            where T : class
        {
            staticHolder.Add(wrapper);
        }
    }
}