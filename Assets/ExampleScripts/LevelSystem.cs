using Newtonsoft.Json;
using UnityEngine;
[System.Serializable]
public class LevelSystem : MonoBehaviour, ISaveable
{
    [SerializeField] private int level = 1;
    [SerializeField] private int xp = 100;

    public object CaptureState()
    {
        return new SaveData
        {
            level = level,
            xp = xp
        };
    }

    public void RestoreState(object state)
    {
        var saveData = JsonConvert.DeserializeObject<SaveData>(state.ToString()); 
        level = saveData.level;
        xp = saveData.xp;
    }

    [System.Serializable]
    private struct SaveData
    {
        public int level;
        public int xp;
    }

}
