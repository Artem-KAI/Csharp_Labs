using DAL.Providers;

public class EntityContext<T>
{
    private readonly DataProvider<T> _provider;

    public EntityContext(DataProvider<T> provider)
    {
        _provider = provider;
    }

    public void Save(string filePath, List<T> entities)
    {
        _provider.Serialize(filePath, entities); 
    }

    public List<T> Load(string filePath)
    {
        return _provider.Deserialize(filePath); 
    }
}



