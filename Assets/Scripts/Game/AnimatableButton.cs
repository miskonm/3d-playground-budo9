using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

namespace Playground.Game
{
    public class AnimatableButton : MonoBehaviour
    {
        #region Variables

        [SerializeField] private TriggerObserver _triggerObserver;
        [SerializeField] private UnityEvent _onPressedEvent;
        [SerializeField] private UnityEvent _onUnPressedEvent;

        [Header("Animation")]
        [SerializeField] private float _pressMoveYDelta = 0.25f;
        [SerializeField] private float _pressAnimationDuration = 1;
        [SerializeField] private Ease _pressAnimationEase = Ease.Linear;
        [SerializeField] private float _unPressDelay = 2f;
        [SerializeField] private float _unPressAnimationDuration = 1;
        [SerializeField] private Ease _unPressAnimationEase = Ease.Linear;

        private bool _isPlayerOnButton;
        private bool _isPressed;
        private Tween _pressAnimation;
        private float _startYPosition;
        private Tween _unPressAnimation;

        #endregion

        #region Unity lifecycle

        private void Awake()
        {
            _startYPosition = transform.position.y;
        }

        private void Start()
        {
            _triggerObserver.OnEntered += TriggerEnteredCallback;
            _triggerObserver.OnExited += TriggerExitedCallback;
        }

        private void OnDestroy()
        {
            _triggerObserver.OnEntered -= TriggerEnteredCallback;
            _triggerObserver.OnExited -= TriggerExitedCallback;
            _unPressAnimation?.Kill();
            _pressAnimation?.Kill();
        }

        #endregion

        #region Private methods

        private bool IsTweenActiveAndPlaying(Tween tween)
        {
            return tween is { active: true } && tween.IsPlaying();
        }

        private void TriggerEnteredCallback(Collider other)
        {
            if (!other.CompareTag(Tag.Player))
            {
                return;
            }

            _isPlayerOnButton = true;
            TryStartPressAnimation();
        }

        private void TriggerExitedCallback(Collider other)
        {
            if (!other.CompareTag(Tag.Player))
            {
                return;
            }

            _isPlayerOnButton = false;
            TryStartUnPressAnimation();
        }

        private void TryStartPressAnimation()
        {
            if (IsTweenActiveAndPlaying(_pressAnimation))
            {
                return;
            }

            _unPressAnimation?.Kill();

            float targetYPosition = _startYPosition - _pressMoveYDelta;
            float ratio = Mathf.Abs((targetYPosition - transform.position.y) / _pressMoveYDelta);
            float duration = ratio * _pressAnimationDuration;

            _pressAnimation = transform
                .DOMoveY(targetYPosition, duration)
                .SetEase(_pressAnimationEase)
                .OnComplete(() =>
                {
                    if (!_isPressed)
                    {
                        _onPressedEvent.Invoke();
                    }

                    _isPressed = true;

                    TryStartUnPressAnimation();
                });
        }

        private void TryStartUnPressAnimation()
        {
            if (_isPlayerOnButton || IsTweenActiveAndPlaying(_pressAnimation))
            {
                return;
            }

            float targetYPosition = _startYPosition;

            Sequence sequence = DOTween.Sequence();
            sequence.AppendInterval(_unPressDelay);
            sequence.Append(
                transform.DOMoveY(targetYPosition, _unPressAnimationDuration).SetEase(_unPressAnimationEase));
            sequence.OnComplete(() =>
            {
                _isPressed = false;
                _onUnPressedEvent.Invoke();
            });

            _unPressAnimation = sequence;
        }

        #endregion
    }
}