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
            Die();
        }
    }

    virtual public void ApplyDamage(float damage) {

        HP = Mathf.Clamp(HP - damage, 0, maxHP);
        Debug.Log(HP);
    }

    virtual public void Die()
    {
        GameManager.instance.UnregisterAtGM(gameObject);
        Destroy(gameObject);
    }
}
