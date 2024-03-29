using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaintMovement : MonoBehaviour
{
     public Transform target;
    public float speed = 1.5f;
     public float rotationSpeed = 5.0f;

    // Define movement boundaries
    public float minX = 480f;
    public float maxX = 520f;
    public float minZ = 329f;
    public float maxZ = 380f;

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            RotateTowardsTarget();
            // Move and restrict within boundaries
            Vector3 newPosition = MoveTowardsTarget();
            transform.position = RestrictMovementWithinBoundaries(newPosition);
        }
    }

       Vector3 MoveTowardsTarget()
    {
        // Calculating the next step towards the target without applying it
        Vector3 step = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        step.y = transform.position.y; // Maintain the current Y position
        return step;
    }

    void RotateTowardsTarget()
    {
        Vector3 targetDirection = target.position - transform.position;
        targetDirection.y = 0; // Ensure rotation is only horizontal

        Quaternion lookRotation = Quaternion.LookRotation(targetDirection);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
    }

    Vector3 RestrictMovementWithinBoundaries(Vector3 proposedPosition)
    {
        //the Giant's position within the specified boundaries
        proposedPosition.x = Mathf.Clamp(proposedPosition.x, minX, maxX);
        proposedPosition.z = Mathf.Clamp(proposedPosition.z, minZ, maxZ);
        
        return proposedPosition;
    }
}
