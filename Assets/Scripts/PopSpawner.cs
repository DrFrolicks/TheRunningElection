using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  

public class PopSpawner : MonoBehaviour {
    public GameObject spawnedObject;
    public int numObjects;  
    public float spawnChance;
    public bool randomizeRotation;
    
    GameObject recentlySpawnedObject; 

    BoxCollider spawnRegion;  
    private void Start()
    { 
        spawnRegion = GetComponent<BoxCollider>(); 
        for(int i = 0; i < numObjects; i++)
        {
            spawn(spawnedObject, false); 
        }
      
    }

    public void spawn(GameObject obj, bool respawnIfInstantlyDestroyed)
    {
        if (Random.value < spawnChance)
        {
            if (respawnIfInstantlyDestroyed)
                StartCoroutine(spawnWithInsuranceCR(obj));
            else
                instantiateWithinBoxCollider(obj).transform.parent = transform; //hack for TRE
        }

    }

    GameObject instantiateWithinBoxCollider(GameObject obj)
    {
        float edgeLimit = 0;
        Quaternion rotation = randomizeRotation ? Quaternion.Euler(Vector3.forward * Random.Range(0, 360)) : rotation = Quaternion.identity;
        
        Transform spawnedObj = Instantiate(obj, transform).transform;
        Vector3 spawnPoint = transform.position + new Vector3(Random.Range(-spawnRegion.size.x / 2 + edgeLimit, spawnRegion.size.x / 2 - edgeLimit),0,
                            Random.Range(-spawnRegion.size.z / 2 + edgeLimit, spawnRegion.size.z / 2 - edgeLimit));

        spawnedObj.position = spawnPoint; 
        return spawnedObj.gameObject; 

    }

    IEnumerator spawnWithInsuranceCR(GameObject obj) 
    {
        recentlySpawnedObject = null;

        while (recentlySpawnedObject == null)  {

            recentlySpawnedObject = instantiateWithinBoxCollider(obj); 
            yield return new WaitForEndOfFrame();
            //Debug.Log("the variable is " + recentlySpawnedObject);
        }
    } 
}
