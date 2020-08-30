using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public List<Side> sides;

    public List<GameObject> actors;

    public List<SpawnData> initialSpawnOrder;

    public List<GameObject> SpawnPoints;

    public static GameManager instance;

    void Awake()
    {
        if (instance != null)
            throw new Exception("GameManager duplication");

        instance = this;

        foreach(SpawnData spawnData in initialSpawnOrder)
        {
            Spawn(spawnData);
        }
    }

    void OnDestroy()
    {
        instance = null;
    }

    public void Spawn(GameObject prefab, Side side, int spawnPoint)
    {
        GameObject spawned = Instantiate(prefab, SpawnPoints[spawnPoint].transform) as GameObject;
        SpawnPoints[spawnPoint].transform.DetachChildren();

        spawned.GetComponent<AI>().updateSide(side);

        Mover spawnedMover = spawned.GetComponent<Mover>();
        if (spawnedMover != null)
            spawned.GetComponent<Mover>().setTarget(SpawnPoints[spawnPoint].GetComponent<SpawnPoint>().firstSign);

        actors.Add(spawned.gameObject);
    }

    public void Spawn(SpawnData spawnData)
    {
        Spawn(spawnData.Prefab, spawnData.Side, spawnData.SpawnPointId);
    }

}
