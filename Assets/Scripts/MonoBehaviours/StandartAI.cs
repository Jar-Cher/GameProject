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
        _mover.FullAhead();
    }

    private void Update()
    {
        if (_gameManager == null)
        {
            _gameManager = GameManager.instance;
            _gameManager.RegisterAtGM(gameObject);
        }

        _attacker.availableEnemies.Clear();
        foreach (GameObject possibleEnemy in side.enemies)
        {
            if ((possibleEnemy != this.gameObject) &&
                (Vector2.SqrMagnitude(transform.position - possibleEnemy.transform.position) <= _attacker.attackRange))
            {
                _attacker.availableEnemies.Add(possibleEnemy);
            }
        }

        if (_attacker.availableEnemies.Count > 0)
        {
            _mover.targetToLook = _attacker.availableEnemies[0];
        }
        else
        {
            _mover.targetToLook = null;
        }
        
    }

}
