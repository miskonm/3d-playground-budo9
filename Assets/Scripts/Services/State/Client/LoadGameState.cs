using Cysharp.Threading.Tasks;
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
            EnterAsync().Forget();
        }

        public override void Exit() { }

        #endregion

        #region Private methods

        private async UniTaskVoid EnterAsync()
        {
            await _sceneLoadingService.LoadSceneAsync(SceneName.Sample);
            StateMachine.Enter<GameState>();
        }

        #endregion
    }
}