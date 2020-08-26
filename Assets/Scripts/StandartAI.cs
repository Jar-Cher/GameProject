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
        if (_attacker.availableEnemies.Count > 0)
        {
            _mover.targetToLook = _attacker.availableEnemies[0];
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        AI other = collision.GetComponent<AI>();
        if (other != null)
            if (side.Enemies.Contains(other.side))
                _attacker.availableEnemies.Add(collision.gameObject);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (_attacker.availableEnemies.Contains(collision.gameObject))
            _attacker.availableEnemies.Remove(collision.gameObject);
    }
}
