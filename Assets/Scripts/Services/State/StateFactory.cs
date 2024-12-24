using Zenject;

namespace Playground.Services.State
{
    public class StateFactory
    {
        #region Variables

        private readonly IInstantiator _instantiator;

        #endregion

        #region Setup/Teardown

        public StateFactory(IInstantiator instantiator)
        {
            _instantiator = instantiator;
        }

        #endregion

        #region Public methods

        public T Create<T>() where T : State
        {
            return _instantiator.Instantiate<T>();
        }

        #endregion
    }
}