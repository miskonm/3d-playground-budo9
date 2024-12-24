using DG.Tweening;
using UnityEngine;

namespace Playground.Game
{
    public class MovingPlatform : MonoBehaviour
    {
        #region Variables

        [SerializeField] private Transform _startPoint;
        [SerializeField] private Transform _endPoint;

        [Header("Animation")]
        [SerializeField] private float _moveDuration = 1f;
        [SerializeField] private Ease _moveEase = Ease.Linear;
        [SerializeField] private float _stayDelay = 2f;

        private Tween _tween;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            transform.position = _startPoint.position;
            StartAnimation();
        }

        private void OnDestroy()
        {
            _tween?.Kill();
        }

        private void OnDrawGizmos()
        {
            if (_startPoint == null || _endPoint == null)
            {
                return;
            }

            Gizmos.color = Color.blue;
            Gizmos.DrawSphere(_startPoint.position, 0.2f);
            Gizmos.DrawSphere(_endPoint.position, 0.2f);
            Gizmos.DrawLine(_startPoint.position, _endPoint.position);
        }

        #endregion

        #region Private methods

        private void StartAnimation()
        {
            Sequence sequence = DOTween.Sequence();
            sequence.AppendInterval(_stayDelay);
            sequence.Append(transform.DOMove(_endPoint.position, _moveDuration).SetEase(_moveEase));
            sequence.AppendInterval(_stayDelay);
            sequence.Append(transform.DOMove(_startPoint.position, _moveDuration).SetEase(_moveEase));
            sequence.SetLoops(-1);
            sequence.SetUpdate(UpdateType.Fixed);

            _tween = sequence;
        }

        #endregion
    }
}