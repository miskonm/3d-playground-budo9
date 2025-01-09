using Playground.Services.Score;
using Playground.Services.UI;

namespace Playground.Services.State.Client
{
    public class BootstrapState : AppState
    {
        #region Variables

        private readonly UIService _uiService;
        private readonly ScoreService _scoreService;

        #endregion

        #region Setup/Teardown

        public BootstrapState(UIService uiService, ScoreService scoreService)
        {
            _uiService = uiService;
            _scoreService = scoreService;
        }

        #endregion

        #region Public methods

        public override void Enter()
        {
            _uiService.Initialize();
            _scoreService.Initialize();
            
            StateMachine.Enter<LoadGameState>();
        }

        public override void Exit() { }

        #endregion
    }
}