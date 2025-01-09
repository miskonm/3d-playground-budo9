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

        #endregion

        #region Setup/Teardown

        public SaveFileProvider()
        {
            _folderPath = Path.Combine(Application.persistentDataPath, FolderName);
        }

        #endregion

        #region Public methods

        public T LoadData<T>() where T : SaveData, new()
        {
            string dataPath = Path.Combine(_folderPath, typeof(T).Name);
            string dataPathWithExtension = GetFilePathWithExtension(dataPath);

            bool isExists = File.Exists(dataPathWithExtension);
            this.Error(
                $"_folderPath '{_folderPath}' dataPathWithExtension '{dataPathWithExtension}' isExists '{isExists}'");

            if (!isExists)
            {
                Directory.CreateDirectory(_folderPath);
                File.WriteAllText(dataPathWithExtension, string.Empty);
                return new T();
            }
            else
            {
                string json = File.ReadAllText(dataPathWithExtension);
                // TODO: Convert to real data
                // return RealData(); 
            }

            return null;
        }

        public void SaveData<T>() where T : SaveData { }

        #endregion

        #region Private methods

        private string GetFilePathWithExtension(string path)
        {
            return $"{path}.json";
        }

        #endregion
    }
}