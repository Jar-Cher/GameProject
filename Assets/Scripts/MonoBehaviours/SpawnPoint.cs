using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public GameObject firstSign;

    private void Awake()
    {
        if (firstSign == null)
        {
            Debug.Log("SpawnPoint is not specified", this);
        }
    }
}
