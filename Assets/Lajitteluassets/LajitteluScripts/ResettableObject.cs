using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script returns objects back to their original position and rotation.
//
// Objects stay where the player leaves them.
// Script allows the game to quickly reset all objects without reloading the whole scene.
//
// attach this script to all grabbable objects

public class ResettableObject : MonoBehaviour
{
    //stores original starting position and rotation
    private Vector3 startPosition;
    private Quaternion startRotation;


    private Rigidbody rb;

    private void Start()
    {
        startPosition = transform.position;
        startRotation = transform.rotation;

        rb = GetComponent<Rigidbody>();
    }

    public void ResetObject()
    {
        // Stop physics movement
        if (rb != null)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }

        // Move object back
        transform.position = startPosition;
        transform.rotation = startRotation;
    }
}
