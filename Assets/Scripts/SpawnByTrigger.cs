using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnByTrigger : MonoBehaviour {
    public GameObject spawnedObject;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Spawn Trigger"))
            Instantiate(spawnedObject, spawnedObject.transform.position, Quaternion.identity);  
    }
}
