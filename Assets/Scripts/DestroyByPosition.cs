using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByPosition : MonoBehaviour {
    public float maxPlayerDistance;
    public Transform playerTransform;
    public bool destroyWhenBehindPlayer, destroyParent; 
	// Use this for initialization
	void Start () {
        if (playerTransform == null)
            playerTransform = GameObject.FindWithTag("Player").transform;  
	}

    // Update is called once per frame
    void Update() {
        if (Vector3.Distance(transform.position, playerTransform.position) > maxPlayerDistance || destroyWhenBehindPlayer && transform.position.z < playerTransform.position.z - 5)
        {
            if (destroyParent)
                Destroy(transform.parent.gameObject);
            else
                Destroy(gameObject); 
        }

	}
}
