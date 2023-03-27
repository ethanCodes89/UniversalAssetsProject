using UnityEngine;
public class LevelSystem : MonoBehaviour, ISaveable
{
    [SerializeField] private int level = 1;
    [SerializeField] private int xp = 100;
    [SerializeField] private Transform playerTransform;

    public object CaptureState()
    {
        SerializeTransform serializedPlayerTransform = new SerializeTransform(transform);

        return new SaveData
        {
            level = level,
            xp = xp,
            playerTransform = serializedPlayerTransform
        };
    }

    public void RestoreState(object state)
    {
        var saveData = (SaveData)state;
        level = saveData.level;
        xp = saveData.xp;
        DeserializeTransformUtility.DeserializeTransform(playerTransform ,saveData.playerTransform); 
    }

    [System.Serializable]
    private struct SaveData
    {
        public int level;
        public int xp;
        public SerializeTransform playerTransform;
    }

}
