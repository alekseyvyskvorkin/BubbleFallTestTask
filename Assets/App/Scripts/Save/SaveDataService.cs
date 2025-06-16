using System.IO;
using Game.Interfaces;
using Newtonsoft.Json;
using UnityEngine;

namespace Game.Save
{
    public class SaveDataService : IDataService
    {
        public T LoadData<T>(string path, T data)
        {
            if (!File.Exists(path))
            {
                PlayerPrefs.SetInt("FirstLaunch", 1);
                SaveData(path, data);
            }

            return JsonConvert.DeserializeObject<T>(File.ReadAllText(path));
        }

        public void SaveData<T>(string path, T data)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }

            using FileStream stream = File.Create(path);
            stream.Close();
            File.WriteAllText(path, JsonConvert.SerializeObject(data));
        }
    }
}
