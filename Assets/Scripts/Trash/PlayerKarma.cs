using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKarma : Karma
{
    public int karma = 4;

    public override void applyKarma()
    {
        Debug.Log(karma);
        karma++;

    }
}
