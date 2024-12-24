using Zenject;

namespace Playground.Services.State
{
    public class StateMachineInstaller : Installer<StateMachineInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<StateMachine>().AsSingle();
            Container.Bind<StateFactory>().AsSingle();
        }
    }
}