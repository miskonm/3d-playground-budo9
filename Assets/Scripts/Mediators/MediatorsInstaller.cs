using Playground.Mediators.Save;
using Zenject;

namespace Playground.Mediators
{
    public class MediatorsInstaller : Installer<MediatorsInstaller>
    {
        #region Public methods

        public override void InstallBindings()
        {
            Container.Bind<IMediator>().To<AutoSaveMediator>().AsSingle();
        }

        #endregion
    }
}