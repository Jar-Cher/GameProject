using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandartAI : AI
{
    private Mover _mover;
    private Attacker _attacker;
    // Start is called before the first frame update

    void Start()
    {
        _mover = GetComponent<Mover>();
        _attacker = GetComponent<Attacker>();
        _mover.fullAhead();
    }

    private void Update()
    {
        _attacker.availableEnemies.Clear();
        foreach (GameObject possibleEnemy in _gameManager.actors)
        {
            if ((possibleEnemy != this) &&
                (side.Enemies.Contains(possibleEnemy.GetComponent<AI>().side)) &&
                (Vector2.Distance(transform.position, possibleEnemy.transform.position) <= _attacker.attackRange))
                    _attacker.availableEnemies.Add(possibleEnemy);
        }

        if (_attacker.availableEnemies.Count > 0)
        {
            _mover.targetToLook = _attacker.availableEnemies[0];
        }
        
    }

}
