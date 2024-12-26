using System;
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

            _tween?.Kill();
        }

        protected override void OnOpen()
        {
            base.OnOpen();

            _closeButton.onClick.AddListener(CloseButtonClickedCallback);

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