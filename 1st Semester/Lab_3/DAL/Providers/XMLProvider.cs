using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace DAL.Providers
{
    public class XmlProvider<T> : DataProvider<T>
    {
        public override void Serialize(string filePath, List<T> data)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
            using (StreamWriter sw = new StreamWriter(filePath))
                serializer.Serialize(sw, data);
        }

        public override List<T> Deserialize(string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
            using (StreamReader sr = new StreamReader(filePath))
                return (List<T>)serializer.Deserialize(sr);
        }
    }
}
