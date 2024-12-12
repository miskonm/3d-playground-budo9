using Playground.Services.Input;
using Zenject;

namespace Playground.Installers
{
    public class ProjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            InputServiceInstaller.Install(Container);
        }
    }
}