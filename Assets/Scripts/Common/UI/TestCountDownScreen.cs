using System;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using NaughtyAttributes;
using Playground.Services.UI;
using TMPro;
using UnityEngine;

namespace Playground.Common.UI
{
    public class TestCountDownScreen : UIScreen
    {
        #region Variables

        private const int StartNumber = 3;

        [SerializeField] private TMP_Text _countDownLabel;
        [SerializeField] private CanvasGroup _canvasGroup;

        [Header("Animation")]
        [SerializeField] private float _fadeInAnimationTime = 2;
        [SerializeField] private Ease _scaleUpEase = Ease.Linear;
        [SerializeField] private Ease _scaleDownEase = Ease.Linear;
        [SerializeField] private float _maxScale = 1.5f;

        private int _currentNumber;
        private Tween _tween;

        #endregion

        #region Events

        public event Action OnCountDownCompleted;

        #endregion

        #region Public methods

        public void StartCountDown()
        {
            Sequence sequence = DOTween.Sequence();
            for (int i = 0; i < StartNumber; i++)
            {
                sequence.Append(_countDownLabel.transform.DOScale(_maxScale, 0.5f).SetEase(_scaleUpEase));
                sequence.Append(_countDownLabel.transform.DOScale(1, 0.5f).SetEase(_scaleDownEase));
                sequence.AppendCallback(() =>
                {
                    _currentNumber--;
                    UpdateCountDownLabel();
                });
            }

            sequence.AppendInterval(0.1f);
            sequence.OnComplete(() => OnCountDownCompleted?.Invoke());
            _tween = sequence;
        }

        #endregion

        #region Protected methods

        protected override void OnClose()
        {
            base.OnClose();

            _tween?.Kill();
        }

        protected override void OnOpen()
        {
            base.OnOpen();

            _currentNumber = StartNumber;
            UpdateCountDownLabel();
        }

        protected override UniTask PlayOpenAnimationAsync()
        {
            return _canvasGroup.DOFade(1, _fadeInAnimationTime).From(0).SetUpdate(true).ToUniTask();
        }

        #endregion

        #region Private methods

        [Button]
        private void TestStart()
        {
            _currentNumber = StartNumber;
            UpdateCountDownLabel();
            StartCountDown();
        }

        private void UpdateCountDownLabel()
        {
            _countDownLabel.text = _currentNumber.ToString();
        }

        #endregion
    }
}