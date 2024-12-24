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

        #endregion
    }
}