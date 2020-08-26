using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    public float HP = 100f;
    public float maxHP = 100f;

    // Update is called once per frame
    virtual public void Update()
    {
        if (HP <= 0)
        {
            this.gameObject.GetComponent<AI>().unregisterAtGM();
            Destroy(this.gameObject);
        }
    }

    virtual public void applyDamage(float damage) {
        Debug.Log(HP);
        HP = Mathf.Clamp(HP - damage, 0, maxHP);
    }
}
