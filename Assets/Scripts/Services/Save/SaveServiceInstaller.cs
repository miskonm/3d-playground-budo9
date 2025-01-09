using Zenject;

namespace Playground.Services.Save
{
    public class SaveServiceInstaller : Installer<SaveServiceInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .Bind<SaveService>()
#if UNITY_EDITOR
                .FromNewComponentOnNewGameObject()
#endif
                .AsSingle();
        }
    }
}