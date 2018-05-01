using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldDimCalc : MonoBehaviour {
    public Vector3 dimensions;

    private void Awake()
    {

        if (dimensions == Vector3.zero)
        {
            BoxCollider bc = GetComponentInChildren<BoxCollider>();
            dimensions = new Vector3(bc.bounds.size.x, bc.bounds.size.y, bc.bounds.size.z);
        }
    }

}
