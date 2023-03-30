using Newtonsoft.Json;
using System.Collections.Generic;
using UnityEngine;

public class SaveableEntity : MonoBehaviour
{
    [SerializeField] private string id = string.Empty;

    public string Id => id;


    private void Awake()
    {
        if(id == string.Empty) id = System.Guid.NewGuid().ToString(); //Only generate a guid if one doesn't already exist
    }

    public object CaptureState()
    {
        var state = new Dictionary<string, object>();

        foreach(var saveable in GetComponents<ISaveable>())
        {
            state[saveable.GetType().ToString()] = saveable.CaptureState();
        }
        return state;
    }

    public void RestoreState(object state)
    {
        var stateDictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(state.ToString());
        
        foreach(var saveable in GetComponents<ISaveable>())
        {
            string typeName = saveable.GetType().ToString();

            if(stateDictionary.TryGetValue(typeName, out object value))
            {
                saveable.RestoreState(value);
            }
        }
    }
}