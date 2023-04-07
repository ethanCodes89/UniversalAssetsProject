using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LoadablePrefabs", menuName = "ScriptableObjects/LoadablePrefabs")]
public class LoadablePrefabs : ScriptableObject
{
    public List<GameObject> Prefabs;
}
