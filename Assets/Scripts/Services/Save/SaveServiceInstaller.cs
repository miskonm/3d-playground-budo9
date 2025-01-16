using Playground.Services.Save.IO;
using UnityEngine;
using Zenject;

namespace Playground.Services.Save
{
    public class SaveServiceInstaller : Installer<SaveServiceInstaller>
    {
        #region Public methods

        public override void InstallBindings()
        {
            Container
                .Bind<SaveService>()
                .FromSubContainerResolve()
                .ByMethod(InstallService)
                .AsSingle();
        }

        #endregion

        #region Private methods

        private void InstallService(DiContainer subContainer)
        {
            subContainer
                .Bind<SaveService>()
#if UNITY_EDITOR
                .FromNewComponentOnNewGameObject()
#endif
                .AsSingle();

            subContainer.Bind<SaveFileProvider>().AsSingle();
            
            // if dev
            subContainer.Bind<ISaveFileIO>().To<SimpleJsonSaveFileIO>().AsSingle();
            // else
            // subContainer.Bind<ISaveFileIO>().To<XMLSaveFileIO>().AsSingle();
        }

        #endregion
    }
}