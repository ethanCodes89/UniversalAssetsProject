using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CameraSaveData : MonoBehaviour, ISaveable
{
    public object CaptureState()
    {
        return new SaveData()
        {
            position = transform.localPosition,
            rotation = transform.localRotation
        };
    }

    public void RestoreState(object state)
    {
        var saveData = JsonConvert.DeserializeObject<SaveData>(state.ToString());
        transform.localPosition = saveData.position;
        transform.localRotation = saveData.rotation;
    }


    [System.Serializable]
    private struct SaveData
    {
        public Vector3 position;
        public Quaternion rotation;
    }
}
