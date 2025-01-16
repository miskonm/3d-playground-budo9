using Playground.Services.Events;
using UnityEngine;
using Zenject;

namespace Playground.Services.AppState
{
    public class AppStateService : MonoBehaviour
    {
        #region Variables

        private EventBus _eventBus;

        #endregion

        #region Setup/Teardown

        [Inject]
        public void Construct(EventBus eventBus)
        {
            _eventBus = eventBus;
        }

        #endregion

        #region Unity lifecycle

        private void OnApplicationFocus(bool hasFocus)
        {
            _eventBus.Publish(new AppStateEvent(hasFocus));
        }

        #endregion
    }
}