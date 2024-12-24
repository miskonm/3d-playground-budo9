using Playground.Services.UI;

namespace Playground.Services.State.Client
{
    public class BootstrapState : AppState
    {
        #region Variables

        private readonly UIService _uiService;

        #endregion

        #region Setup/Teardown

        public BootstrapState(UIService uiService)
        {
            _uiService = uiService;
        }

        #endregion

        #region Public methods

        public override void Enter()
        {
            _uiService.Initialize();
            
            StateMachine.Enter<LoadGameState>();
        }

        public override void Exit() { }

        #endregion
    }
}