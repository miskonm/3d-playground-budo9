using Playground.Services.State;
using Playground.Services.State.Client;
using UnityEngine;
using Zenject;

namespace Playground.Infrastructure
{
    public class GameBootstrapper : MonoBehaviour
    {
        #region Variables

        private StateMachine _stateMachine;

        #endregion

        #region Setup/Teardown

        [Inject]
        public void Construct(StateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            _stateMachine.Enter<BootstrapState>();
        }

        #endregion
    }
}