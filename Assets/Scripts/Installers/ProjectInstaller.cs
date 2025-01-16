using Playground.Mediators;
using Playground.ScreenControllers;
using Playground.Services.AppState;
using Playground.Services.Coroutines;
using Playground.Services.Events;
using Playground.Services.Input;
using Playground.Services.Pause;
using Playground.Services.Save;
using Playground.Services.SceneLoading;
using Playground.Services.Score;
using Playground.Services.State;
using Playground.Services.TestCountDown;
using Playground.Services.UI;
using Zenject;

namespace Playground.Installers
{
    public class ProjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            InputServiceInstaller.Install(Container);
            UIServiceInstaller.Install(Container);
            StateMachineInstaller.Install(Container);
            SceneLoadingServiceInstaller.Install(Container);
            CoroutineRunnerInstaller.Install(Container);
            PauseServiceInstaller.Install(Container);
            ScreenControllersInstaller.Install(Container);
            TestCountDownServiceInstaller.Install(Container);
            ScoreServiceInstaller.Install(Container);
            SaveServiceInstaller.Install(Container);
            EventBusInstaller.Install(Container);
            AppStateServiceInstaller.Install(Container);
            MediatorsInstaller.Install(Container);
        }
    }
}