using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    public float attackRange = 4f;
    public float damage = 8f;
    public float reloadTime = 1f;

    public List<GameObject> availableEnemies;

    protected private float lastShot;

    // Start is called before the first frame update
    void Awake()
    {
        GetComponent<CircleCollider2D>().radius = attackRange;
        lastShot = Time.time;
    }

}
