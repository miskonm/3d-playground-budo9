using Zenject;

namespace Playground.Services.SceneLoading
{
    public class SceneLoadingServiceInstaller : Installer<SceneLoadingServiceInstaller>
    {
        #region Public methods

        public override void InstallBindings()
        {
            Container.Bind<SceneLoadingService>().AsSingle();
        }

        #endregion
    }
}