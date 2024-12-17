using DG.Tweening;
using Playground.Utils.Logger;
using UnityEngine;

namespace Playground.Game
{
    public class OpeningDoor : MonoBehaviour
    {
        #region Variables

        [Header("Block Settings")]
        [SerializeField] private float _moveDistanceY = 3f;
        [SerializeField] private float _moveDuration = 2f;
        [SerializeField] private float _delayBeforeReturn = 3f;

        [Header("Effect shaking")]
        [SerializeField] private float _shakeDuration = 0.5f;
        [SerializeField] private float _shakeStrength = 0.5f;
        [SerializeField] private int _shakeVibrato = 10;

        private Vector3 _initialPosition;
        private Tween _openAnimation;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            _initialPosition = transform.position;
        }

        private void OnDestroy()
        {
            _openAnimation?.Kill();
        }

        #endregion

        #region Public methods

        public void Close()
        {
            this.Error();
        }

        public void Open()
        {
            this.Error();
            Interact();
        }

        #endregion

        #region Private methods

        private void Interact()
        {
            _openAnimation?.Kill(true);

            float targetPositionY = _initialPosition.y + _moveDistanceY;
            Sequence sequence = DOTween.Sequence();
            sequence.Append(transform.DOShakePosition(_shakeDuration, _shakeStrength, _shakeVibrato));
            sequence.Append(transform.DOMoveY(targetPositionY, _moveDuration));
            sequence.AppendInterval(_delayBeforeReturn);
            sequence.Append(transform.DOMoveY(_initialPosition.y, _moveDuration));

            _openAnimation = sequence;
        }

        #endregion
    }
}