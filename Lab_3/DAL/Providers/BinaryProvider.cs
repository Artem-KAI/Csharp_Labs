using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

#pragma warning disable SYSLIB0011 
namespace DAL.Providers
{
    public class BinaryProvider<T> : DataProvider<T>
    {
        public override void Serialize(string filePath, List<T> data)
        {
            using FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(fs, data);
        }

        public override List<T> Deserialize(string filePath)
        {
            using FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            BinaryFormatter formatter = new BinaryFormatter();
            return (List<T>)formatter.Deserialize(fs);
        }
    }
}
