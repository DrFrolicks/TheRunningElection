using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityKinematic : MonoBehaviour {

    public Vector3 velocity;
    Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + velocity * Time.deltaTime);
    }
}
