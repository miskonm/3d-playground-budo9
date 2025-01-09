using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Playground.Services.Save
{
    public class SaveService
#if UNITY_EDITOR
        : MonoBehaviour
#endif
    {
        #region Variables

        private readonly Dictionary<Type, SaveData> _dataByTypes = new();
        private SaveFileProvider _saveFileProvider;

        #endregion

        #region Setup/Teardown

        [Inject]
        public void Construct()
        {
            _saveFileProvider = new SaveFileProvider();
        }

        #endregion

        #region Public methods

        public T GetData<T>() where T : SaveData, new()
        {
            Type type = typeof(T);
            if (_dataByTypes.TryGetValue(type, out SaveData value))
            {
                return value as T;
            }

            T data = _saveFileProvider.LoadData<T>();
            _dataByTypes.Add(type, data);

            return data;
        }

        public void Save<T>() where T : SaveData
        {
            _saveFileProvider.SaveData<T>();
        }

        public void SaveAll()
        {
            // foreach (Type type in _dataByTypes.Keys)
            // {
            //     
            // }
        }

        #endregion
    }
}