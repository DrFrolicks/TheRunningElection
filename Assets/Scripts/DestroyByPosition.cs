using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByPosition : MonoBehaviour {
    public float maxPlayerDistance;
    public Transform playerTransform; 
	// Use this for initialization
	void Start () {
        if (playerTransform == null)
            playerTransform = GameObject.FindWithTag("Player").transform;  
	}
	
	// Update is called once per frame
	void Update () {
        if (Vector3.Distance(transform.position, playerTransform.position) > maxPlayerDistance)
            Destroy(gameObject); 
	}
}
