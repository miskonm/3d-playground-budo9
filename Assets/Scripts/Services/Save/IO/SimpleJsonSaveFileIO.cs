using System.IO;
using UnityEngine;

namespace Playground.Services.Save.IO
{
    public class SimpleJsonSaveFileIO : ISaveFileIO
    {
        #region ISaveFileIO

        public T Load<T>(string path) where T : class
        {
            string serializedData = File.ReadAllText(path);
            return JsonUtility.FromJson<T>(serializedData);
        }

        public void Save(object obj, string path)
        {
            string json = JsonUtility.ToJson(obj);
            File.WriteAllText(path, json);
        }

        #endregion
    }
}