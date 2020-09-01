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

    virtual public void SetSpeed(float newSpeed)
    {
        allowedSpeed = Mathf.Clamp(newSpeed, -maxSpeed, maxSpeed);
    }

    virtual public void FullAhead()
    {
        allowedSpeed = maxSpeed;
    }

    virtual public void Stop()
    {
        allowedSpeed = 0;
    }

    virtual public void SetTarget(GameObject newTarget)
    {
        targetToMove = newTarget;
    }

    public bool IsLookingAtTarget()
    {
        if (targetToLook == null)
        {
            Vector3 targetDirection = (targetToMove.transform.position - transform.position).normalized;
            return (targetDirection - transform.right).magnitude < 0.01;
        }
        else
        {
            Vector3 targetDirection = (targetToLook.transform.position - transform.position).normalized;
            return (targetDirection - transform.right).magnitude < 0.01;
        }
    }
}
