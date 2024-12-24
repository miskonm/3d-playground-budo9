using Zenject;

namespace Playground.Services.Coroutines
{
    public class CoroutineRunnerInstaller : Installer<CoroutineRunnerInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<CoroutineRunner>().FromNewComponentOnNewGameObject().AsSingle();
        }
    }
}