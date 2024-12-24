namespace Playground.Services.State
{
    public class StateMachine
    {
        #region Variables

        private readonly StateFactory _factory;

        private State _currentState;

        #endregion

        #region Setup/Teardown

        public StateMachine(StateFactory factory)
        {
            _factory = factory;
        }

        #endregion

        #region Public methods

        public void Enter<T>() where T : AppState
        {
            _currentState?.Exit();
            T state = _factory.Create<T>();
            _currentState = state;
            _currentState.Setup(this);
            state.Enter();
        }

        public void Enter<TState, TPayload>(TPayload payload) where TState : PayloadAppState<TPayload>
        {
            _currentState?.Exit();
            TState state = _factory.Create<TState>();
            _currentState = state;
            _currentState.Setup(this);
            state.Enter(payload);
        }

        #endregion
    }
}