using System;
using System.IO;
using Playground.Utils.Logger;
using UnityEngine;

namespace Playground.Services.Save
{
    public class SaveFileProvider
    {
        #region Variables

        private const string FolderName = "Save";

        private readonly string _folderPath;
        private readonly ISaveFileIO _saveFileIO;

        #endregion

        #region Setup/Teardown

        public SaveFileProvider(ISaveFileIO saveFileIO)
        {
            _saveFileIO = saveFileIO;
            _folderPath = Path.Combine(Application.persistentDataPath, FolderName);
        }

        #endregion

        #region Public methods

        public T LoadData<T>() where T : SaveData, new()
        {
            string dataPath = Path.Combine(_folderPath, typeof(T).Name);
            string dataPathWithExtension = GetFilePathWithExtension(dataPath);

            bool isExists = File.Exists(dataPathWithExtension);

            if (!isExists)
            {
                Directory.CreateDirectory(_folderPath);
                File.WriteAllText(dataPathWithExtension, string.Empty);
                return new T();
            }

            T obj = null;

            try
            {
                obj = _saveFileIO.Load<T>(dataPathWithExtension);
            }
            catch (Exception e)
            {
                this.Error($"e '{e}'");
            }

            if (obj == null)
            {
                obj = new T();
            }

            return obj;
        }

        public void SaveData<T>(T data) where T : SaveData
        {
            string name = data.GetType().Name;
            string dataPath = Path.Combine(_folderPath, name);
            string dataPathWithExtension = GetFilePathWithExtension(dataPath);

            bool isExists = File.Exists(dataPathWithExtension);

            if (!isExists)
            {
                Directory.CreateDirectory(_folderPath);
            }

            try
            {
                _saveFileIO.Save(data, dataPathWithExtension);
            }
            catch (Exception e)
            {
                this.Error($"e '{e}'");
            }
        }

        #endregion

        #region Private methods

        private string GetFilePathWithExtension(string path)
        {
            return $"{path}.txt";
        }

        #endregion
    }
}