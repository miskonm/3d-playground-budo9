using Playground.Common.UI;
using Playground.ScreenControllers;
using Playground.Services.Pause;
using Playground.Services.UI;
using Playground.Utils.Logger;

namespace Playground.Services.State.Client
{
    public class GameState : AppState
    {
        #region Variables

        private readonly UIService _uiService;
        private readonly PauseService _pauseService;
        private readonly PauseScreenController _pauseScreenController;

        private GameScreen _gameScreen;

        #endregion

        #region Setup/Teardown

        public GameState(UIService uiService, PauseService pauseService, PauseScreenController pauseScreenController)
        {
            _uiService = uiService;
            _pauseService = pauseService;
            _pauseScreenController = pauseScreenController;
        }

        #endregion

        #region Public methods

        public override void Enter()
        {
            this.Error();

            _pauseService.Initialize();
            _pauseScreenController.Initialize();

            _gameScreen = _uiService.OpenScreen<GameScreen>();
        }

        public override void Exit()
        {
            _pauseService.Dispose();
            _pauseScreenController.Dispose();
            
            _uiService.CloseScreen(_gameScreen);
        }

        #endregion
    }
}