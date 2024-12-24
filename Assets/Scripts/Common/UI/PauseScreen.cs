using System;
using System.Collections;
using System.Threading.Tasks;
using DG.Tweening;
using Playground.Services.UI;
using Playground.Utils.Logger;
using UnityEngine;
using UnityEngine.UI;

namespace Playground.Common.UI
{
    public class PauseScreen : UIScreen
    {
        #region Variables

        [Header(nameof(PauseScreen))]
        [SerializeField] private Button _closeButton;

        [Header("Animation")]
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private float _animationTime = 1f;
        
        [Header("Test")]
        [SerializeField] private Button _coroutineButton;
        [SerializeField] private Button _taskButton;
        

        private Tween _tween;

        #endregion

        #region Events

        public event Action OnCloseButtonClicked;

        #endregion

        #region Protected methods

        protected override void OnClose()
        {
            base.OnClose();

            _closeButton.onClick.RemoveListener(CloseButtonClickedCallback);
            _coroutineButton.onClick.RemoveListener(CoroutineButtonClickedCallback);
            _taskButton.onClick.RemoveListener(TaskButtonClickedCallback);

            _tween?.Kill();
        }

        private void TaskButtonClickedCallback2()
        {
            this.Error($"Start");
            try
            {
                TaskButtonClickedCallback();
            }
            catch (Exception e)
            {
                this.Error($"EXCEPTION '{e}'");
            }
            
            this.Error("End");
            
        }

        private async void TaskButtonClickedCallback()
        {
            this.Error($"Start");
            try
            {
                await TestTaskAsync();
            }
            catch (Exception e)
            {
                this.Error($"EXCEPTION '{e}'");
            }
            
            this.Error("End");
        }

        private async Task TestTaskAsync()
        {
            this.Error($"Start");
            await Task.Delay(1000);
            // try
            // {
                throw new TimeoutException("Ololol");
            // }
            // catch (Exception e)
            // {
            //     this.Error($"EXCEPTION '{e}'");
            //     
            // }
            
            this.Error("End");
        }

        private void CoroutineButtonClickedCallback()
        {
            this.Error($"Start");
            StartCoroutine(TestCoroutine());
            this.Error("End");
        }

        private IEnumerator TestCoroutine()
        {
            this.Error($"Start");
            yield return new WaitForSecondsRealtime(1);
            this.Error("End");
        }

        protected override void OnOpen()
        {
            base.OnOpen();

            _closeButton.onClick.AddListener(CloseButtonClickedCallback);
            _coroutineButton.onClick.AddListener(CoroutineButtonClickedCallback);
            _taskButton.onClick.AddListener(TaskButtonClickedCallback);
            
            PlayOpenAnimation();
        }

        #endregion

        #region Private methods

        private void CloseButtonClickedCallback()
        {
            this.Error();
            OnCloseButtonClicked?.Invoke();
        }

        private void PlayOpenAnimation()
        {
            _tween = _canvasGroup.DOFade(1, _animationTime).From(0).SetUpdate(true);
        }

        #endregion
    }
}