using Playground.Common.UI;
using Playground.Services.Pause;
using Playground.Services.UI;

namespace Playground.ScreenControllers
{
    public class PauseScreenController
    {
        #region Variables

        private readonly PauseService _pauseService;
        private readonly UIService _uiService;

        private PauseScreen _screen;

        #endregion

        #region Setup/Teardown

        public PauseScreenController(PauseService pauseService, UIService uiService)
        {
            _pauseService = pauseService;
            _uiService = uiService;
        }

        #endregion

        #region Public methods

        public void Dispose()
        {
            _pauseService.OnPauseChanged -= PauseChangedCallback;
            CloseScreen();
        }

        public void Initialize()
        {
            _pauseService.OnPauseChanged += PauseChangedCallback;
        }

        #endregion

        #region Private methods

        private void CloseButtonClickedCallback()
        {
            _pauseService.Unpause();
        }

        private void CloseScreen()
        {
            if (_screen == null)
            {
                return;
            }

            _screen.OnCloseButtonClicked -= CloseButtonClickedCallback;
            _uiService.CloseScreen(_screen);
            _screen = null;
        }

        private void OpenScreen()
        {
            _screen = _uiService.OpenScreen<PauseScreen>();
            _screen.OnCloseButtonClicked += CloseButtonClickedCallback;
        }

        private void PauseChangedCallback()
        {
            if (_pauseService.IsPaused)
            {
                OpenScreen();
            }
            else
            {
                CloseScreen();
            }
        }

        #endregion
    }
}