using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointDasher : MonoBehaviour {
    public Transform[] points;
    public int currentPointIndex;
    public float dashForce;

    bool canDash;
    private void Start()
    {
        canDash = true; 
    }
    public void dashToPoint(int pointIndex)
    {
        GetComponent<Rigidbody>().AddForce((points[pointIndex].position - transform.position).normalized * dashForce);
        currentPointIndex = pointIndex; 
    }

    public void dashInDirection(float axisValue)
    {
        if (!canDash || axisValue == 0) return;  
        int destinationPIndex = 0; 
        if(axisValue < 0)
        {
            if (currentPointIndex > 0)
                destinationPIndex = currentPointIndex - 1;
            else
                return;  
        } 
        if(axisValue > 0)
        {
            if (currentPointIndex < points.Length - 1)
                destinationPIndex = currentPointIndex + 1;
            else
                return; 
        }
        dashToPoint(destinationPIndex);
        canDash = false;
        Debug.Log(canDash);  
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("LanePoint") && other.transform == points[currentPointIndex])
        {
            canDash = true;
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        }

    }
}
