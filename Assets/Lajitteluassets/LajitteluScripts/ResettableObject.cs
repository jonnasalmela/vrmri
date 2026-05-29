using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResettableObject : MonoBehaviour
{
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
