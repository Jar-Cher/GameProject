using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignSystem : MonoBehaviour
{
    private List<GameObject> signs = new List<GameObject>();

    public Side side;

    void updateSigns()
    {
        foreach (Transform child in transform)
        {
            if (!signs.Contains(child.gameObject))
                signs.Add(child.gameObject);
        }
    }

    private void Awake()
    {
        updateSigns();
    }

    public void unChoseAll()
    {
        foreach (GameObject sign in signs)
        {
            sign.GetComponent<Sign>().isChosen = false;
            sign.GetComponent<Sign>().setImpossible();
        }
    }
}
