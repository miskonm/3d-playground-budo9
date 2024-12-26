using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Playground.Services.UI
{
    public abstract class UIScreen : MonoBehaviour
    {
        #region Variables

        private UniTaskCompletionSource _openAnimationTCS;

        #endregion

        #region Properties

        public UniTask OpenAnimationTask => _openAnimationTCS.Task;

        #endregion

        #region Unity lifecycle

        private void Awake()
        {
            _openAnimationTCS = new UniTaskCompletionSource();
        }

        #endregion

        #region Public methods

        public void Close()
        {
            OnClose();
            // TODO: Nikita fix it plz
            PlayCloseAnimationAsync().Forget();
        }

        public void Open()
        {
            OnOpen();
            PlayOpenAnimationInternalAsync().Forget();
        }

        #endregion

        #region Protected methods

        protected virtual void OnClose() { }
        protected virtual void OnOpen() { }

        protected virtual UniTask PlayCloseAnimationAsync()
        {
            return UniTask.CompletedTask;
        }

        protected virtual UniTask PlayOpenAnimationAsync()
        {
            return UniTask.CompletedTask;
        }

        #endregion

        #region Private methods

        private async UniTaskVoid PlayOpenAnimationInternalAsync()
        {
            await PlayOpenAnimationAsync();
            _openAnimationTCS.TrySetResult();
        }

        #endregion
    }
}