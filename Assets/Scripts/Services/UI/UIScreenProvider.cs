using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Assertions;

namespace Playground.Services.UI
{
    public class UIScreenProvider
    {
        #region Variables

        private const string FolderPath = "UI/Screens";

        private readonly Dictionary<Type, UIScreen> _prefabsByType = new();

        #endregion

        #region Public methods

        public T GetPrefab<T>() where T : UIScreen
        {
            Type type = typeof(T);
            if (!_prefabsByType.ContainsKey(type))
            {
                LoadPrefab<T>();
            }

            return _prefabsByType[type] as T;
        }

        #endregion

        #region Private methods

        private void LoadPrefab<T>() where T : UIScreen
        {
            Type type = typeof(T);
            string fullPath = Path.Combine(FolderPath, type.Name);
            T uiScreen = Resources.Load<T>(fullPath);
            Assert.IsNotNull(uiScreen, $"There is no prefab for screen '{type.Name}'");
            _prefabsByType.Add(type, uiScreen);
        }

        #endregion
    }
}