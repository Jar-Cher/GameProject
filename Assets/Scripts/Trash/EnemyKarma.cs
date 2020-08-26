using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKarma : Karma
{

    public int karma = 0;

    public override void applyKarma()
    {
        Debug.Log(karma);
        karma = karma - 1;

    }
}
