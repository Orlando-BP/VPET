using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataBase
{
    public string path = Application.persistentDataPath;
    public void SaveData<T>(string saveName, T saveData)
    {
        string JsonToSave = JsonUtility.ToJson(saveData);
        File.WriteAllText
            (
            path + "/" + saveName + ".json", 
            JsonToSave
            );
    }

    public void LoadData<T>(string saveName,System.Action<T> callback)
    {
        if(File.Exists(path + "/" + saveName + ".json"))
        {
            string LoadedJson = File.ReadAllText(path + "/" + saveName + ".json");
            callback(JsonUtility.FromJson<T>(LoadedJson));
        }
        else
        {
            Debug.Log("El archivo no existe");
        }
    }
    public void DeleteData(string saveName)
    {
        File.Delete(path + "/" + saveName + ".json");
    }
}
