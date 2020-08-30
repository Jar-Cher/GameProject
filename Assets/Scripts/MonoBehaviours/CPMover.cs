using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CPMover : Mover
{

    private GameObject prevTarget;

    // Update is called once per frame
    void Update()
    {
        if (targetToMove != null)
            if (Vector2.Distance(targetToMove.transform.position, transform.position) < 0.5)
                targetToMove = targetToMove.GetComponent<Sign>().nextSign;

        if (isLookingAtTarget() && (targetToLook == null))
        {
            float newSpeed = 0f;
            if (_rb2d.velocity.magnitude > allowedSpeed)
            {
                newSpeed = _rb2d.velocity.magnitude - acceleration * Time.deltaTime;
            }
            else
            {
                newSpeed = Mathf.Clamp(_rb2d.velocity.magnitude + acceleration * Time.deltaTime, 0.0f, allowedSpeed);
            }
            _rb2d.velocity = ((Vector2)transform.right * newSpeed);
        }
        else
        {
            if (targetToLook)
                TurnToLook(targetToLook);
            else
                TurnToLook(targetToMove);
            float newSpeed = Mathf.Clamp(_rb2d.velocity.magnitude - acceleration * Time.deltaTime * 5, 0.0f, allowedSpeed);
            _rb2d.velocity = ((Vector2)transform.right * newSpeed);
        }
    }

    void TurnToLook(GameObject toLookAt)
    {
        float angle = Mathf.Atan2(toLookAt.transform.position.y - transform.position.y, toLookAt.transform.position.x - transform.position.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

}
