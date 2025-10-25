using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DAL.Providers
{
    public class CustomProvider<T> : DataProvider<T> where T : class
    {
        public override void Serialize(string filePath, List<T> data)
        {
            var lines = data.Select(d => string.Join(";", d.GetType().GetProperties().Select(p => p.GetValue(d))));
            File.WriteAllLines(filePath, lines);
        }

        public override List<T> Deserialize(string filePath)
        {
            return new List<T>();
        }
    }
}
