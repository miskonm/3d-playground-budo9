using System.Collections.Generic;
using Playground.Mediators;
using Playground.Services.Score;
using Playground.Services.UI;

namespace Playground.Services.State.Client
{
    public class BootstrapState : AppState
    {
        #region Variables

        private readonly List<IMediator> _mediators;
        private readonly ScoreService _scoreService;
        private readonly UIService _uiService;

        #endregion

        #region Setup/Teardown

        public BootstrapState(List<IMediator> mediators, UIService uiService, ScoreService scoreService)
        {
            _mediators = mediators;
            _uiService = uiService;
            _scoreService = scoreService;
        }

        #endregion

        #region Public methods

        public override void Enter()
        {
            InitializeServices();
            InitializeMediators();

            StateMachine.Enter<LoadGameState>();
        }

        public override void Exit() { }

        #endregion

        #region Private methods

        private void InitializeMediators()
        {
            foreach (IMediator mediator in _mediators)
            {
                mediator.Initialize();
            }
        }

        private void InitializeServices()
        {
            _uiService.Initialize();
            _scoreService.Initialize();
        }

        #endregion
    }
}