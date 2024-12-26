using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Playground.Services.SceneLoading
{
    public class SceneLoadingService
    {
        #region Public methods

        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }

        public async UniTask LoadSceneAsync(string sceneName)
        {
            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName);

            while (!asyncOperation.isDone)
            {
                await UniTask.Yield();
            }

            await UniTask.Yield();
        }

        #endregion
    }
}