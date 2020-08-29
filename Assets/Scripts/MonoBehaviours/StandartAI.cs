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
            // GetComponent в Update в foreach уже может быть неприятен при большом количестве юнитов. O(n^2)
            // (Vector2.SqrMagnitude(transform.position - possibleEnemy.transform.position) <= _attacker.sqrAttackRange)) сильно дешевле без потери понятности

            // Я бы в инстансе своей стороны (не настройки Side) хранил список enemies, а в attacker при готовности к атаке выбирал кого ударить из всего списка,
            // таким образом нет необходимости каждый кадр проходится по всем actors, только при изменении, а атакер получает возможность самостоятельно определять кого он может атаковать.
            if ((possibleEnemy != this) &&
                (side.Enemies.Contains(possibleEnemy.GetComponent<AI>().side)) &&
                (Vector2.Distance(transform.position, possibleEnemy.transform.position) <= _attacker.attackRange))
                    _attacker.availableEnemies.Add(possibleEnemy);
            // У таких больших ифов лучше иметь скобочки для читаемости. В ВГ принято для оджнострочных без скобок, для многострочных (учловий или тел) со скобками
        }

        if (_attacker.availableEnemies.Count > 0)
        {
            _mover.targetToLook = _attacker.availableEnemies[0];
        }
        
    }

}
