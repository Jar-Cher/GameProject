using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Side", menuName = "Side", order = 51)]
public class Side : ScriptableObject
{
    [SerializeField]
    private Color color;
    [SerializeField]
    private List<Side> enemies;
    [SerializeField]
    private bool isPlayerControlled;

    public Color Color
    {
        get
        {
            return color;
        }
    }

    public List<Side> Enemies
    {
        get
        {
            return enemies;
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
