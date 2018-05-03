using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpraySplat : MonoBehaviour {

    public GameObject spray;

    private void OnCollisionEnter(Collision collision)
    {
        if(!collision.gameObject.CompareTag("Player"))
        {
            Vector3 collisionNormal = collision.contacts[0].normal;
            Transform sProp = Instantiate(spray, collision.contacts[0].point + collisionNormal * 0.1f, Quaternion.identity).transform; 
            sProp.transform.up = collisionNormal;
            sProp.transform.Rotate(0, 180, 0);
            sProp.transform.parent = collision.transform; 
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("PropSurface"))
        {
            collision.gameObject.GetComponent<PropagandaSurface>().hit();
        }
    }
}
