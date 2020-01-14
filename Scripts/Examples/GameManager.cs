using System.Threading.Tasks;

using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;

namespace StaticEvil.Examples
{
    public class GameManager : MonoBehaviour
    {
        private static Evil<ShopManager> shopManager;

        async void Start()
        {
            shopManager = FindObjectOfType<ShopManager>();

            await Task.Delay(1000);

            var operation = SceneManager.LoadSceneAsync(1);

            // ShopManager is being destroyed here:
            while (operation.isDone)
                await Task.Yield();

            await Task.Delay(1000);

            Assert.IsNull(shopManager.Value);
        }
    }
}
