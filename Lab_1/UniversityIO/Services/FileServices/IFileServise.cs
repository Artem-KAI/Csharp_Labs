namespace UniversityIO.Services.FileServices
{
    public interface IFileService<T>
    {
        void SaveData(string path, T[] data);

        T[] LoadData(string path);
    }
}
