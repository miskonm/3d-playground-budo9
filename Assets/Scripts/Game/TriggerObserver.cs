using System;
using UnityEngine;

namespace Playground.Game
{
    public class TriggerObserver : MonoBehaviour
    {
        #region Events

        public event Action<Collider> OnEntered;
        public event Action<Collider> OnExited;
        public event Action<Collider> OnStayed;

        #endregion

        #region Unity lifecycle

        public void OnTriggerEnter(Collider other)
        {
            OnEntered?.Invoke(other);
        }

        private void OnTriggerExit(Collider other)
        {
            OnExited?.Invoke(other);
        }

        private void OnTriggerStay(Collider other)
        {
            OnStayed?.Invoke(other);
        }

        #endregion
    }
}