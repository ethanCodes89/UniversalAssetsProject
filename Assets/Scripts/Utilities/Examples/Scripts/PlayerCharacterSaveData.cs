using Newtonsoft.Json;
using UnityEngine;

[System.Serializable]
public class PlayerCharacterSaveData : MonoBehaviour, ISaveable
{
    [SerializeField] private int level = 1;
    [SerializeField] private int xp = 100;

    public object CaptureState()
    {
        return new SaveData
        {
            level = level,
            xp = xp,
            position = transform.localPosition,
            rotation = transform.localRotation,
            scale = transform.localScale
        };
    }

    public void RestoreState(object state)
    {
        var saveData = JsonConvert.DeserializeObject<SaveData>(state.ToString()); 
        level = saveData.level;
        xp = saveData.xp;
        transform.localPosition = saveData.position;
        transform.localRotation = saveData.rotation;
        transform.localScale = saveData.scale;
    }

    [System.Serializable]
    private struct SaveData
    {
        public int level;
        public int xp;
        public Vector3 position;
        public Quaternion rotation;
        public Vector3 scale;
    }

}
