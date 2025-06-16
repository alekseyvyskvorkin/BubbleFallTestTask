using UnityEngine;

namespace Game.Save
{
    public class SaveSystem
    {
        public SaveData SaveData = new SaveData();

        private SaveDataService _saveDataService = new SaveDataService();

        private string _saveDataPath = Application.persistentDataPath + "/SaveData.json";

        public SaveSystem()
        {
#if UNITY_EDITOR
            _saveDataPath = Application.dataPath + "/App/Data/SaveData.json";
#else
            _saveDataPath = Application.persistentDataPath + "/SaveData.json";
#endif
            var saveData = _saveDataService.LoadData(_saveDataPath, SaveData);
            SaveData = saveData;
        }

        public void Save()
        {
            _saveDataService.SaveData(_saveDataPath, SaveData);
        }
    }
}
