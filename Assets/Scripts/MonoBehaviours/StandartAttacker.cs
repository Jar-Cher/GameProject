using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandartAttacker : Attacker
{

    private Mover _mover;

    private void Awake()
    {
        _mover = GetComponent<Mover>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (((reloadTime + lastShot) < Time.time) && (availableEnemies.Count > 0) && (_mover.IsLookingAtTarget()))
        {
            Shoot();
        }
    }

    // Shoot
    void Shoot()
    {
        lastShot = Time.time;
        availableEnemies[0].GetComponent<Health>().ApplyDamage(damage);
    }
}
