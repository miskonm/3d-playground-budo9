using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Playground.Services.UI
{
    public class UIService : IUIServiceInternal
    {
        #region Variables

        private readonly UIScreenFactory _factory;
        private readonly UILayersController _layersController;
        private readonly UIScreenProvider _screenProvider;

        #endregion

        #region Setup/Teardown

        public UIService(UILayersController layersController, UIScreenProvider screenProvider, UIScreenFactory factory)
        {
            _layersController = layersController;
            _screenProvider = screenProvider;
            _factory = factory;
        }

        #endregion

        #region IUIServiceInternal

        void IUIServiceInternal.CloseScreenInternal(UIScreen uiScreen)
        {
            Object.Destroy(uiScreen.gameObject);
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
        }

        public void Initialize()
        {
            _layersController.Initialize();
        }

        public T OpenScreen<T>() where T : UIScreen
        {
            Transform layerParent = _layersController.GetLayerParent();
            T screenPrefab = _screenProvider.GetPrefab<T>();
            T uiScreen = _factory.Create(screenPrefab, layerParent);
            uiScreen.Open();
            return uiScreen;
        }

        public async UniTask<T> OpenScreenAsync<T>() where T : UIScreen
        {
            T uiScreen = await CreateScreenInstanceAsync<T>();
            uiScreen.Open();
            return uiScreen;
        }

        public async UniTask<TScreen> OpenScreenAsync<TScreen, TModel>(TModel model) where TScreen : UIScreen<TModel>
        {
            TScreen uiScreen = await CreateScreenInstanceAsync<TScreen>();
            uiScreen.SetModel(model);
            uiScreen.Open();
            return uiScreen;
        }

        #endregion

        #region Private methods

        private async UniTask<T> CreateScreenInstanceAsync<T>() where T : UIScreen
        {
            Transform layerParent = _layersController.GetLayerParent();
            T screenPrefab = await _screenProvider.GetPrefabAsync<T>();
            T uiScreen = _factory.Create(screenPrefab, layerParent);
            return uiScreen;
        }

        #endregion
    }
}