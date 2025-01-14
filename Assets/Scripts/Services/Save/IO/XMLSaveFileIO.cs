using System.IO;
using System.Xml.Serialization;

namespace Playground.Services.Save.IO
{
    public class XMLSaveFileIO : ISaveFileIO
    {
        #region ISaveFileIO

        public T Load<T>(string path) where T : class
        {
            XmlSerializer serializer = new(typeof(T));
            using StreamReader reader = new(path);
            T deserialized = (T)serializer.Deserialize(reader.BaseStream);
            return deserialized;
        }

        public void Save(object obj, string path)
        {
            XmlSerializer serializer = new(obj.GetType());
            using StreamWriter writer = new(path);
            serializer.Serialize(writer.BaseStream, obj);
        }

        #endregion
    }
}