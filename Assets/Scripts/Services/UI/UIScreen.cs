using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Playground.Services.UI
{
    public abstract class UIScreen : MonoBehaviour
    {
        #region Variables

        private UniTaskCompletionSource _closeAnimationTCS;
        private UniTaskCompletionSource _openAnimationTCS;

        #endregion

        #region Properties

        public UniTask CloseAnimationTask => _closeAnimationTCS.Task;
        public UniTask OpenAnimationTask => _openAnimationTCS.Task;

        protected UIService UIService { get; private set; }

        #endregion

        #region Setup/Teardown

        [Inject]
        public void Construct(UIService uiService)
        {
            UIService = uiService;
            _openAnimationTCS = new UniTaskCompletionSource();
            _closeAnimationTCS = new UniTaskCompletionSource();
        }

        #endregion

        #region Public methods

        public void Close()
        {
            CloseInternalAsync().Forget();
        }

        public UniTask CloseAsync()
        {
            return CloseInternalAsync();
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

        private async UniTask CloseInternalAsync()
        {
            OnClose();

            await PlayCloseAnimationAsync();

            _closeAnimationTCS.TrySetResult();

            ((IUIServiceInternal)UIService).CloseScreenInternal(this);
        }

        private async UniTaskVoid PlayOpenAnimationInternalAsync()
        {
            await PlayOpenAnimationAsync();
            _openAnimationTCS.TrySetResult();
        }

        #endregion
    }

    public abstract class UIScreen<TModel> : UIScreen
    {
        #region Properties

        protected TModel ScreenModel { get; private set; }

        #endregion

        #region Public methods

        public void SetModel(TModel model)
        {
            ScreenModel = model;
        }

        #endregion
    }
}