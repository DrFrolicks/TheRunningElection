using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour {
    public GameObject car;
    public float twoCarChance, oneCarChance;
    public float spawnIntevalSec;
    public Transform[] lanePoints;
    public int spawnOffsetY;
    private void Start()
    {
        spawnWave(); 
    }
    public void spawnWave()
    {
        float randomNum = Random.value;
        int numCars = 0; 
        if(randomNum < twoCarChance) numCars = 2;
        if (randomNum < oneCarChance) numCars = 1;

        ArrayList openPoints = new ArrayList();
        openPoints.AddRange(lanePoints);
        ArrayList selectedPoints = new ArrayList(); 

        for(int i = 0; i < numCars; i++)
        {
            int pointIndex = Random.Range(0, openPoints.Count);
            selectedPoints.Add(openPoints[pointIndex]);
            openPoints.RemoveAt(pointIndex); 
        }

        foreach(Transform spawnPoint in selectedPoints)
        {
            Instantiate(car, spawnPoint.position + Vector3.forward * spawnOffsetY, Quaternion.identity);  
        }

        Invoke("spawnWave", spawnIntevalSec); 
    }

}
