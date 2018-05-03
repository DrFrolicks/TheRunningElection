using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropagandaSurface : MonoBehaviour {
    public GameObject display;  
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
        display.SetActive(true);
        hasPropaganda = true;
    } 

    
}
