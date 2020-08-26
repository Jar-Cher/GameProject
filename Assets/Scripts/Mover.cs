using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Mover : MonoBehaviour
{
    protected Rigidbody2D _rb2d;

    public GameObject targetToMove;
    public GameObject targetToLook = null;
    public float maxSpeed = 10f;
    public float allowedSpeed = 0f;
    public float acceleration = 5f;
    public float rotationSpeed = 50f;


    void Awake()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }

    virtual public void setSpeed(float newSpeed)
    {
        allowedSpeed = Mathf.Clamp(newSpeed, -maxSpeed, maxSpeed);
    }

    virtual public void fullAhead()
    {
        allowedSpeed = maxSpeed;
    }

    virtual public void stop()
    {
        allowedSpeed = 0;
    }

    virtual public void setTarget(GameObject newTarget)
    {
        targetToMove = newTarget;
    }
}
