using System.Collections.Generic;

namespace DAL.Providers
{
    public abstract class DataProvider<T>
    {
        public abstract void Serialize(string filePath, List<T> data);
        public abstract List<T> Deserialize(string filePath);
    }
}

//using System.Collections.Generic;

//namespace DAL.Providers
//{
//    public abstract class DataProvider<T>
//    {
//        public abstract void Save(string filePath, List<T> data);
//        public abstract List<T> Load(string filePath);
//    }
//}
