using Zenject;

namespace Playground.Services.Pause
{
    public class PauseServiceInstaller : Installer<PauseServiceInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<PauseService>().FromNewComponentOnNewGameObject().AsSingle();
        }
    }
}