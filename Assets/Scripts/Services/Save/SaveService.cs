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

#if UNITY_EDITOR
        // TODO: Nikita add drawer
        [SerializeField] private List<SaveData> _debugSaves = new();
#endif

        private readonly Dictionary<Type, SaveData> _dataByTypes = new();

        private SaveFileProvider _saveFileProvider;

        #endregion

        #region Setup/Teardown

        [Inject]
        public void Construct(SaveFileProvider saveFileProvider)
        {
            _saveFileProvider = saveFileProvider;
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
            AddToCache(type, data);

            return data;
        }

        public void Save<T>() where T : SaveData
        {
            Type type = typeof(T);
            if (!_dataByTypes.TryGetValue(type, out SaveData value))
            {
                return;
            }

            _saveFileProvider.SaveData(value);
        }

        public void SaveAll()
        {
            foreach (SaveData saveData in _dataByTypes.Values)
            {
                _saveFileProvider.SaveData(saveData);
            }
        }

        #endregion

        #region Private methods

        private void AddToCache(Type type, SaveData data)
        {
            _dataByTypes.Add(type, data);

#if UNITY_EDITOR
            _debugSaves.Add(data);
#endif
        }

        #endregion
    }
}