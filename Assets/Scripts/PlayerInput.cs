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
        if (ApplicationManager.instance.gameIsPaused) return;
        if (Input.GetButtonDown("Fire1"))
        {
            cannon.shoot(); 
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            cannon.reload();  
        }

        GetComponent<PointDasher>().dashInDirection(Input.GetAxisRaw("Horizontal")); 
	}
}
