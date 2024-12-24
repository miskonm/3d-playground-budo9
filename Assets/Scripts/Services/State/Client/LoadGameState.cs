using Playground.Services.SceneLoading;

namespace Playground.Services.State.Client
{
    public class LoadGameState : AppState
    {
        #region Variables

        private readonly SceneLoadingService _sceneLoadingService;

        #endregion

        #region Setup/Teardown

        public LoadGameState(SceneLoadingService sceneLoadingService)
        {
            _sceneLoadingService = sceneLoadingService;
        }

        #endregion

        #region Public methods

        public override void Enter()
        {
            _sceneLoadingService.LoadScene(SceneName.Sample);
            StateMachine.Enter<GameState>();
        }

        public override void Exit() { }

        #endregion
    }
}