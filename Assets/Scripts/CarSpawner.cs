using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour {
    public GameObject car;
    public float twoCarChance, oneCarChance;
    public float spawnRowRate;
    public Transform[] lanePoints; 

    public void spawnWave()
    {
        float randomNum = Random.value;
        int numCars = 0; 
        if(randomNum < twoCarChance) numCars = 2;
        if (randomNum < oneCarChance) numCars = 1;

        ArrayList openPoints = new ArrayList();
        openPoints.AddRange(lanePoints);
        ArrayList selectedPoints = new ArrayList(); 

    }

}
