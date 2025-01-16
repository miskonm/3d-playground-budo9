using Zenject;

namespace Playground.Services.AppState
{
    public class AppStateServiceInstaller : Installer<AppStateServiceInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<AppStateService>().FromNewComponentOnNewGameObject().AsSingle().NonLazy();
        }
    }
}