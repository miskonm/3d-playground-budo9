using UnityEngine;

namespace Playground.Game.Player
{
    public class PlayerAnimation : MonoBehaviour
    {
        #region Variables

        private static readonly int IsGrounded = Animator.StringToHash("isGrounded");
        private static readonly int Speed = Animator.StringToHash("speed");
        private static readonly int SpeedX = Animator.StringToHash("speedX");
        private static readonly int SpeedY = Animator.StringToHash("speedY");
        private static readonly int SpeedZ = Animator.StringToHash("speedZ");

        [SerializeField] private Animator _animator;

        #endregion

        #region Public methods

        public void SetGrounded(bool isGrounded)
        {
            _animator.SetBool(IsGrounded, isGrounded);
        }

        public void SetMovement(Vector2 axisWithSpeed)
        {
            _animator.SetFloat(Speed, axisWithSpeed.magnitude);
            _animator.SetFloat(SpeedX, axisWithSpeed.x);
            _animator.SetFloat(SpeedZ, axisWithSpeed.y);
        }

        public void SetSpeedY(float fallVectorY)
        {
            _animator.SetFloat(SpeedY, fallVectorY);
        }

        #endregion
    }
}