using UnityEngine;

namespace Playground.Services.UI
{
    public abstract class UIScreen : MonoBehaviour
    {
        #region Public methods

        public void Close()
        {
            OnClose();
        }

        public void Open()
        {
            OnOpen();
        }

        #endregion

        #region Protected methods

        protected virtual void OnClose() { }
        protected virtual void OnOpen() { }

        #endregion
    }
}