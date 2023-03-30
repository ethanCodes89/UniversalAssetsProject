using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


public class SavingAndLoading : Singleton<SavingAndLoading>
{
    public string GameName;
    private string saveFolder;
    private string completeFileLocation;
    private void Awake()
    {
        saveFolder = Application.persistentDataPath + "/Saves/";
        if (!Directory.Exists(saveFolder))
        {
            Directory.CreateDirectory(saveFolder);
        }
        completeFileLocation = saveFolder + GameName + ".json";
        Debug.Log("Savepath located at: " + saveFolder); //Helps us find the json file
    }
    #region SaveAndLoadCommands
    [ContextMenu("Save")]
    private void Save()
    {
        var state = LoadFile();
        CaptureState(state);
        SaveFile(state);
    }

    [ContextMenu("Load")]
    private void Load()
    {
        var state = LoadFile();
        RestoreState(state);
    }

    [ContextMenu("Delete")]
    private void DeleteData()
    {
        if (File.Exists(completeFileLocation))
        File.Delete(completeFileLocation);
    }
    #endregion

    private void SaveFile(object state)
    {
        string jsonString = JsonConvert.SerializeObject(state, Formatting.Indented);
        File.WriteAllText(completeFileLocation, jsonString);
    }

    private Dictionary<string, object> LoadFile()
    {
        if(!File.Exists(completeFileLocation))
        {
            Debug.LogError("No File To Load");
            return new Dictionary<string, object>();
        }
        string json = File.ReadAllText(saveFolder + GameName + ".json");
        return JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
    }

    private void CaptureState(Dictionary<string, object> state)
    {
        foreach(var saveable in FindObjectsOfType<SaveableEntity>())
        {
            state[saveable.Id] = saveable.CaptureState();
        }
    }

    private void RestoreState(Dictionary<string, object> state)
    {
        foreach(var saveable in FindObjectsOfType<SaveableEntity>())
        {
            if(state.TryGetValue(saveable.Id, out object value))
            {
                saveable.RestoreState(value);
            }
        }
    }
}
