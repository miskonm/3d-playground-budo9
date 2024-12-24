using UnityEngine;

namespace Playground.Services.UI
{
    public class UILayerMarkers : MonoBehaviour
    {
        #region Variables

        [SerializeField] private Canvas _canvas;

        #endregion

        #region Properties

        public Transform CanvasTransform => _canvas.transform;

        #endregion
    }
}