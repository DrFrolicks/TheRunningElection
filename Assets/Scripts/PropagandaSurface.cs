using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropagandaSurface : MonoBehaviour {
    public int votesAwarded;
    ParticleSystem particleSystem;

    bool hasPropaganda = false;  
    private void Awake()
    {
        particleSystem = GetComponent<ParticleSystem>();  
    }

    public void hit()
    {
        if (hasPropaganda) return; 

        GameManager.instance.addVotes(votesAwarded);
        particleSystem.Play();
        hasPropaganda = true;
        Debug.Log("hit"); 
    } 
    
    
}
