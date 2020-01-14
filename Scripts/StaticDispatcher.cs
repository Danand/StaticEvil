using UnityEngine;
using UnityEngine.SceneManagement;

namespace StaticEvil
{
    internal static class StaticDispatcher
    {
        private static StaticHolder staticHolder;

        [RuntimeInitializeOnLoadMethod]
        public static void InitializeOnLoad()
        {
            if (Application.isPlaying)
            {
                SceneManager.sceneLoaded += OnSceneLoaded;
                SceneManager.sceneUnloaded += OnSceneUnloaded;

                staticHolder = CreateHolder();
            }
        }

        public static void DestroyOnCurrentSceneUnloaded<T>(Evil<T> wrapper)
            where T : class
        {
            staticHolder.Add(wrapper);
        }

        private static void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
        {
            if (loadSceneMode == LoadSceneMode.Single)
                staticHolder = CreateHolder();
        }

        private static void OnSceneUnloaded(Scene scene)
        {
            staticHolder = null;
        }

        private static StaticHolder CreateHolder()
        {
            var holder = new GameObject(nameof(StaticHolder)).AddComponent<StaticHolder>();
            holder.hideFlags = HideFlags.HideInHierarchy;
            return holder;
        }
    }
}