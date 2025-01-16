using NaughtyAttributes;
using Playground.Services.Input;
using UnityEngine;
using Zenject;

namespace Playground.Game.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        #region Variables

        [SerializeField] private PlayerAnimation _animation;
        [SerializeField] private CharacterController _controller;
        [SerializeField] private float _speed = 10f;
        [SerializeField] private float _runSpeed = 20f;

        [Header("Ground")]
        [SerializeField] private Transform _checkGroundTransform;
        [SerializeField] private float _checkGroundRadius = 1;
        [SerializeField] private LayerMask _checkGroundLayerMask;

        [Header("Jump")]
        [SerializeField] private float _jumpHeight = 1f;
        [SerializeField] private float _gravityModifier = 1f;

        [Header("Debug")]
        [ReadOnly]
        [SerializeField] private Vector3 _fallVector;
        [ReadOnly]
        [SerializeField] private Vector3 _moveVector;

        private InputService _inputService;

        #endregion

        #region Properties

        public Vector3 Velocity => _moveVector;

        #endregion

        #region Setup/Teardown

        [Inject]
        public void Construct(InputService inputService)
        {
            _inputService = inputService;
        }

        #endregion

        #region Unity lifecycle

        private void Update()
        {
            Vector2 axis = _inputService.Axis;
            _moveVector = transform.right * axis.x + transform.forward * axis.y;
            float speed = _inputService.IsRun ? _runSpeed : _speed;
            _moveVector *= speed;

            bool isGrounded =
                Physics.CheckSphere(_checkGroundTransform.position, _checkGroundRadius, _checkGroundLayerMask);

            if (isGrounded && _fallVector.y < 0)
            {
                _fallVector.y = 0;
            }

            Vector3 gravity = Physics.gravity * _gravityModifier;

            if (isGrounded && _inputService.IsJump)
            {
                _fallVector.y = Mathf.Sqrt(_jumpHeight * -3f * gravity.y);
            }

            _fallVector += gravity * Time.deltaTime;

            _animation.SetMovement(axis * speed);
            _animation.SetGrounded(isGrounded);
            _animation.SetSpeedY(_fallVector.y);
        }

        private void FixedUpdate()
        {
            _controller.Move(_moveVector * Time.fixedDeltaTime);
            _controller.Move(_fallVector * Time.fixedDeltaTime);
        }

        private void OnDrawGizmos()
        {
            if (_checkGroundTransform != null)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawWireSphere(_checkGroundTransform.position, _checkGroundRadius);
            }
        }

        #endregion
    }
}