using Cinemachine;
using UnityEngine;

namespace Playground.Game.Player
{
    public class PlayerRotator : MonoBehaviour
    {
        #region Variables

        [SerializeField] private CinemachineFreeLook _freeLook;
        [SerializeField] private PlayerMovement _movement;

        #endregion

        #region Unity lifecycle

        private void Awake()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        private void Update()
        {
            if (_movement.Velocity.magnitude > 0)
            {
                Quaternion quaternion = Quaternion.Euler(0, _freeLook.m_XAxis.Value, 0);
                transform.rotation = Quaternion.Slerp(transform.rotation, quaternion, 0.5f);
            }
        }

        #endregion
    }
}