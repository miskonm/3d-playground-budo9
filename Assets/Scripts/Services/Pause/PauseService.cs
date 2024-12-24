using System;
using UnityEngine;

namespace Playground.Services.Pause
{
    public class PauseService : MonoBehaviour
    {
        #region Variables

        private bool _isInitialized;
        private bool _isPaused;

        #endregion

        #region Events

        public event Action OnPauseChanged;

        #endregion

        #region Properties

        public bool IsPaused
        {
            get => _isPaused;
            private set
            {
                bool needNotify = _isPaused != value;

                _isPaused = value;
                Time.timeScale = _isPaused ? 0 : 1;

                if (needNotify)
                {
                    OnPauseChanged?.Invoke();
                }
            }
        }

        #endregion

        #region Unity lifecycle

        private void Update()
        {
            if (!_isInitialized)
            {
                return;
            }

            if (UnityEngine.Input.GetKeyDown(KeyCode.Escape))
            {
                TogglePause();
            }
        }

        #endregion

        #region Public methods

        public void Dispose()
        {
            Unpause();
            _isInitialized = false;
        }

        public void Initialize()
        {
            _isInitialized = true;
        }

        public void Pause()
        {
            if (!_isInitialized)
            {
                return;
            }

            IsPaused = true;
        }

        public void Unpause()
        {
            if (!_isInitialized)
            {
                return;
            }

            IsPaused = false;
        }

        #endregion

        #region Private methods

        private void TogglePause()
        {
            IsPaused = !IsPaused;
        }

        #endregion
    }
}