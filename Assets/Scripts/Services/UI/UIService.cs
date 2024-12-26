using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Playground.Services.UI
{
    public class UIService
    {
        #region Variables

        private readonly UILayersController _layersController;
        private readonly UIScreenProvider _screenProvider;

        #endregion

        #region Setup/Teardown

        public UIService(UILayersController layersController, UIScreenProvider screenProvider)
        {
            _layersController = layersController;
            _screenProvider = screenProvider;
        }

        #endregion

        #region Public methods

        public void CloseScreen<T>(T screen) where T : UIScreen
        {
            if (screen == null)
            {
                return;
            }

            screen.Close();
            Object.Destroy(screen.gameObject);
        }

        public void Initialize()
        {
            _layersController.Initialize();
        }

        public T OpenScreen<T>() where T : UIScreen
        {
            Transform layerParent = _layersController.GetLayerParent();
            T screenPrefab = _screenProvider.GetPrefab<T>();
            T uiScreen = Object.Instantiate(screenPrefab, layerParent);
            uiScreen.Open();
            return uiScreen;
        }

        public async UniTask<T> OpenScreenAsync<T>() where T : UIScreen
        {
            Transform layerParent = _layersController.GetLayerParent();
            T screenPrefab = await _screenProvider.GetPrefabAsync<T>();
            T uiScreen = Object.Instantiate(screenPrefab, layerParent);
            uiScreen.Open();
            return uiScreen;
        }

        #endregion
    }
}