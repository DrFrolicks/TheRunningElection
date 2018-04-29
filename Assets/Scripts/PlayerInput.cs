using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Weapons;  

public class PlayerInput : MonoBehaviour {
    // Update is called once per frame
    Cannon cannon; 
    private void Awake()
    {
        cannon = GetComponentInChildren<Cannon>(); 
    }
    void Update() {
        if (Input.GetButtonDown("Fire1"))
        {
            cannon.shoot();
            Debug.Log("book"); 
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            cannon.reload();  
        }
	}
}
