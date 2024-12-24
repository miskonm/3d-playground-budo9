using UnityEngine;

namespace Playground.Services.UI
{
    public class UILayersController
    {
        #region Variables

        private const string PrefabPath = "UIService";

        private readonly Transform _parentTransform;

        private UILayerMarkers _layerMarkers;

        #endregion

        #region Setup/Teardown

        public UILayersController(Transform parentTransform)
        {
            _parentTransform = parentTransform;
        }

        #endregion

        #region Public methods

        public Transform GetLayerParent()
        {
            return _layerMarkers.CanvasTransform;
        }

        public void Initialize()
        {
            UILayerMarkers prefab = Resources.Load<UILayerMarkers>(PrefabPath);
            _layerMarkers = Object.Instantiate(prefab, _parentTransform);
        }

        #endregion
    }
}