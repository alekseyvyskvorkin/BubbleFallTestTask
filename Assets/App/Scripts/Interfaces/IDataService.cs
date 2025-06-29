namespace Game.Interfaces
{
    public interface IDataService
    {
        void SaveData<T>(string path, T data);
        T LoadData<T>(string path, T data);
    }
}
