using UnityEngine;
using Zenject;

namespace Playground.Services.UI
{
    public class UIScreenFactory
    {
        #region Variables

        private readonly IInstantiator _instantiator;

        #endregion

        #region Setup/Teardown

        public UIScreenFactory(IInstantiator instantiator)
        {
            _instantiator = instantiator;
        }

        #endregion

        #region Public methods

        public T Create<T>(T prefab, Transform parent) where T : UIScreen
        {
            return _instantiator.InstantiatePrefabForComponent<T>(prefab, parent);
        }

        #endregion
    }
}