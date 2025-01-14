namespace Playground.Services.Save
{
    public interface ISaveFileIO
    {
        #region Public methods

        T Load<T>(string path) where T : class;
        void Save(object obj, string path);

        #endregion
    }
}