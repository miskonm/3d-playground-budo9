using Zenject;

namespace Playground.Services.TestCountDown
{
    public class TestCountDownServiceInstaller : Installer<TestCountDownServiceInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<TestCountDownService>().FromNewComponentOnNewGameObject().AsSingle().NonLazy();
        }
    }
}