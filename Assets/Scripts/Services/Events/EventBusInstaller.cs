using Zenject;

namespace Playground.Services.Events
{
    public class EventBusInstaller : Installer<EventBusInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<EventBus>().AsSingle();
        }
    }
}