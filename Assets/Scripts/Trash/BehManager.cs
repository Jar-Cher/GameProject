using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehManager : MonoBehaviour
{

    public List<Karma> objs;

    // Start is called before the first frame update
    void Update()
    {

        foreach (Karma i in objs)
        {
            i.applyKarma();
        }
    }

}
