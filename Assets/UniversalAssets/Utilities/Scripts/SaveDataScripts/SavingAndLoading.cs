using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.InputSystem;
using UniversalAssetsProject.Utilities;

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
    public void Save()
    {
        var state = File.Exists(completeFileLocation) ? JsonConversions.DeserializeToDictionary(completeFileLocation) : new Dictionary<string, object>();
        CaptureState(state);
       JsonConversions.SerializeToJson(state, completeFileLocation);
    }

    public void Load()
    {
        if (!File.Exists(completeFileLocation))
        {
            Debug.LogError("No File To Load");
            return;
        }
        var state = JsonConversions.DeserializeToDictionary(completeFileLocation);
        RestoreState(state);
    }

    public void DeleteData()
    {
        if (File.Exists(completeFileLocation))
        File.Delete(completeFileLocation);
    }
    #endregion

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
