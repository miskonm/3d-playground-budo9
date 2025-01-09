using Zenject;

namespace Playground.Services.Score
{
    public class ScoreServiceInstaller : Installer<ScoreServiceInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .Bind<ScoreService>()
#if UNITY_EDITOR
                .FromNewComponentOnNewGameObject()
#endif
                .AsSingle()
                .NonLazy();
        }
    }
}