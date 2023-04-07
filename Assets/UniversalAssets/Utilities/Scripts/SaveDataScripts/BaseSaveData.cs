using Newtonsoft.Json;
using UnityEngine;

/*This is a base class that can be inherited from for any object that needs to have persistent data saved between plays. 
 */

[System.Serializable]
public class BaseSaveData : MonoBehaviour, ISaveable
{
    public object CaptureState()
    {
        return new SaveData
        {
            position = transform.localPosition,
            rotation = transform.localRotation,
            scale = transform.localScale
        };
    }

    public void RestoreState(object state)
    {
        var saveData = JsonConvert.DeserializeObject<SaveData>(state.ToString());
        transform.localPosition = saveData.position;
        transform.localRotation = saveData.rotation;
        transform.localScale = saveData.scale;
    }

    [System.Serializable]
    private struct SaveData
    {
        public Vector3 position;
        public Quaternion rotation;
        public Vector3 scale;
    }

}
