using Cysharp.Threading.Tasks;
using Playground.Common.UI;
using Playground.Services.UI;
using UnityEngine;
using Zenject;

namespace Playground.Services.TestCountDown
{
    public class TestCountDownService : MonoBehaviour
    {
        #region Variables

        private TestCountDownScreen _screen;
        private UIService _uiService;

        #endregion

        #region Setup/Teardown

        [Inject]
        public void Construct(UIService uiService)
        {
            _uiService = uiService;
        }

        #endregion

        #region Unity lifecycle

        private void Update()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.T) && _screen == null)
            {
                OpenScreenAsync().Forget();
            }
        }

        #endregion

        #region Private methods

        private void CountDownCompletedCallback()
        {
            _screen.OnCountDownCompleted -= CountDownCompletedCallback;
            // await _screen.CloseAsync(); TODO: Nikita do it. And fix close from screen.
            _uiService.CloseScreen(_screen);
            _screen = null;
        }

        private async UniTaskVoid OpenScreenAsync()
        {
            // TODO: Nikita implement models in screen
            _screen = await _uiService.OpenScreenAsync<TestCountDownScreen>();
            _screen.OnCountDownCompleted += CountDownCompletedCallback;
            await _screen.OpenAnimationTask;
            _screen.StartCountDown();
        }

        #endregion
    }
}