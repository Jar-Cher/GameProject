using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Side", menuName = "Side", order = 51)]
public class Side : ScriptableObject
{
    [SerializeField]
    private Color color;
    [SerializeField]
    private List<Side> enemySides;
    [SerializeField]
    private bool isPlayerControlled;

    public List<GameObject> enemies;

    public Color Color
    {
        get
        {
            return color;
        }
    }

    public List<Side> EnemySides
    {
        get
        {
            return enemySides;
        }
    }

    public bool IsPlayerControlled
    {
        get
        {
            return isPlayerControlled;
        }
    }
}
