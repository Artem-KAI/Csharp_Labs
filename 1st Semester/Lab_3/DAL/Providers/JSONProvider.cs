using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace DAL.Providers
{
    public class JsonProvider<T> : DataProvider<T>
    {
        public override void Serialize(string filePath, List<T> data)
        {
            var json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }

        public override List<T> Deserialize(string filePath)
        {
            var json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<T>>(json);
        }
    }
}
