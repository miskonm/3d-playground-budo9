namespace Playground.Services.State
{
    public abstract class State
    {
        #region Properties

        protected StateMachine StateMachine { get; private set; }

        #endregion

        #region Public methods

        public abstract void Exit();

        public void Setup(StateMachine stateMachine)
        {
            StateMachine = stateMachine;
        }

        #endregion
    }
}