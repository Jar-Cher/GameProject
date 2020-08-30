using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New SpawnData", menuName = "SpawnData", order = 52)]
public class SpawnData : ScriptableObject
{
    [SerializeField]
    private GameObject prefab;
    [SerializeField]
    private Side side;
    [SerializeField]
    private int spawnPointId;

    public GameObject Prefab
    {
        get
        {
            return prefab;
        }
    }

    public Side Side
    {
        get
        {
            return side;
        }
    }

    public int SpawnPointId
    {
        get
        {
            return spawnPointId;
        }
    }
}
