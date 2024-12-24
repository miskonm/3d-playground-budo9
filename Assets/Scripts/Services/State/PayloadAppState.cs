namespace Playground.Services.State
{
    public abstract class PayloadAppState<T> : State
    {
        #region Public methods

        public abstract void Enter(T payload);

        #endregion
    }
}