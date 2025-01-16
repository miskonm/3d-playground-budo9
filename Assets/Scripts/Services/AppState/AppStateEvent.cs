namespace Playground.Services.AppState
{
    public class AppStateEvent
    {
        #region Variables

        public readonly bool hasFocus;

        #endregion

        #region Setup/Teardown

        public AppStateEvent(bool hasFocus)
        {
            this.hasFocus = hasFocus;
        }

        public AppStateEvent() { }

        #endregion
    }
}