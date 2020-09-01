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

        foreach(Side side in sides)
        {
            side.enemies = new List<GameObject>();
        }

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

        spawned.GetComponent<AI>().UpdateSide(side);

        Mover spawnedMover = spawned.GetComponent<Mover>();
        if (spawnedMover != null)
            spawned.GetComponent<Mover>().SetTarget(SpawnPoints[spawnPoint].GetComponent<SpawnPoint>().firstSign);

        //RegisterAtGM(spawned);
    }

    public void Spawn(GameObject prefab, Side side, GameObject spawnLocation)
    {
        GameObject spawned = Instantiate(prefab, spawnLocation.transform) as GameObject;
        spawnLocation.transform.DetachChildren();

        spawned.GetComponent<AI>().UpdateSide(side);

        Mover spawnedMover = spawned.GetComponent<Mover>();
        if (spawnedMover != null)
            spawned.GetComponent<Mover>().SetTarget(spawnLocation.GetComponent<SpawnPoint>().firstSign);

        //RegisterAtGM(spawned);
    }

    public void Spawn(SpawnData spawnData)
    {
        Spawn(spawnData.Prefab, spawnData.Side, spawnData.SpawnPointId);
    }

    public void RegisterAtGM(GameObject actor)
    {
        Debug.Log("Checking...");
        if (IsRegistered(actor))
        {
            return;
        }
        Debug.Log("Check complete!");
        actors.Add(actor);
        foreach(Side side in sides)
        {
            if (side.EnemySides.Contains(actor.GetComponent<AI>().side))
            {
                side.enemies.Add(actor);
            }
        }
    }

    public void UnregisterAtGM(GameObject actor)
    {
        actors.Remove(actor);
        foreach (Side side in sides)
        {
            Debug.Log("Deleting", actor);
            if (side.EnemySides.Contains(actor.GetComponent<AI>().side))
            {
                side.enemies.Remove(actor);
            }
        }
    }

    public bool IsRegistered(GameObject instance)
    {
        return actors.Contains(instance);
    }

}
