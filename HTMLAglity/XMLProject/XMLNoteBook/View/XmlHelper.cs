using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XMLNoteBook.View
{
    public class XmlHelper
    {
        public static T Load<T>(string path) where T : new ()
        {
            var serializer = new XmlSerializer(typeof(T));

            if (!File.Exists(path))
                return new T();

            using var fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            return (T)serializer.Deserialize(fs);
        }

        public static void Save<T>(string path, T data)
        {
            var serializer = new XmlSerializer(typeof(T));

            using var fs = new FileStream(path, FileMode.Create, FileAccess.Write);
            serializer.Serialize(fs, data);
        }
    }
}
