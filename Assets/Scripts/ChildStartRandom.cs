using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildStartRandom : MonoBehaviour {
    public GameObject[] possibleChildren; 
	// Use this for initialization
	void Start () {
        Instantiate(possibleChildren[Random.Range(0, possibleChildren.Length)], transform); 
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
