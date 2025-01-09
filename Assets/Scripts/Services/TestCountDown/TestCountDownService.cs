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

        private int _showNumber;
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
            _screen.Close();
            _screen = null;
        }

        private async UniTaskVoid OpenScreenAsync()
        {
            TestCountDownScreen.Model model = new()
            {
                startNumber = _showNumber > 2 ? 3 : 1,
                countDownCompletedCallback = CountDownCompletedCallback,
            };

            _screen = await _uiService.OpenScreenAsync<TestCountDownScreen, TestCountDownScreen.Model>(model);
            _showNumber++;
            await _screen.OpenAnimationTask;
            _screen.StartCountDown();
        }

        #endregion
    }
}