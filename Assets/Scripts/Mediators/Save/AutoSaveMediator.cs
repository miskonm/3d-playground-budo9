using Playground.Services.AppState;
using Playground.Services.Events;
using Playground.Services.Save;
using Playground.Utils.Logger;

namespace Playground.Mediators.Save
{
    public class AutoSaveMediator : IMediator
    {
        #region Variables

        private readonly EventBus _eventBus;
        private readonly SaveService _saveService;

        #endregion

        #region Setup/Teardown

        public AutoSaveMediator(EventBus eventBus, SaveService saveService)
        {
            _eventBus = eventBus;
            _saveService = saveService;
        }

        #endregion

        #region IMediator

        public void Initialize()
        {
            _eventBus.Subscribe<AppStateEvent>(AppStateChangedCallback);
        }

        #endregion

        #region Private methods

        private void AppStateChangedCallback(AppStateEvent args)
        {
            if (!args.hasFocus)
            {
                _saveService.SaveAll();
            }
        }

        #endregion
    }
}