using DAL;
using DAL.Base;
using DAL.Providers;

namespace BLL
{
    public static class ProviderFactory
    {
        public static EntityService CreateService(string serializationType)
        {
            DataProvider<Person> provider = serializationType switch
            {
                "1" => new BinaryProvider<Person>(),
                "2" => new XmlProvider<Person>(),
                "3" => new JsonProvider<Person>(),
                "4" => new CustomProvider<Person>(),
                _ => new JsonProvider<Person>()
            };

            var context = new EntityContext<Person>(provider);
            return new EntityService(context);
        }
    }
}
