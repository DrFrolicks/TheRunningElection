using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinMovement : MonoBehaviour {
    public Rigidbody rb;
    public float moveSpeed, amplitude, frequency;
    private float startingY;

    private float radianInput = 0;  
    private void Start()
    {
        startingY = transform.position.y;  
        
    }

    void Update () {
        transform.LookAt(GameObject.FindWithTag("Player").transform); 
        transform.position += (transform.right * moveSpeed * Time.deltaTime); 

        radianInput += frequency * Time.deltaTime;  
        transform.position = new Vector3(transform.position.x, (startingY + Mathf.Sin(radianInput)), transform.position.z);
    }
}
