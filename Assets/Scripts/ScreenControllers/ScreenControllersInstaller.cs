using Zenject;

namespace Playground.ScreenControllers
{
    public class ScreenControllersInstaller : Installer<ScreenControllersInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<PauseScreenController>().AsSingle();
        }
    }
}