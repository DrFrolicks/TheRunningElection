using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialStartRandom : MonoBehaviour {
    public Material[] materials;
    MeshRenderer meshRenderer;
    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();  
    }
    // Use this for initialization
    void Start () {
        meshRenderer.material = materials[Random.Range(0, materials.Length)]; 
	}

}
