using System.Collections.Generic;
using DAL.Entities;
using DAL.Providers;

namespace DAL
{
    public class EntityContext
    {
        private readonly DataProvider<Student> _provider;

        public EntityContext(DataProvider<Student> provider)
        {
            _provider = provider;
        }

        public void Save(string filePath, List<Student> students)
        {
            _provider.Serialize(filePath, students);
        }

        public List<Student> Load(string filePath)
        {
            return _provider.Deserialize(filePath);
        }
    }
}
