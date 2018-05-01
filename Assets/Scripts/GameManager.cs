using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events; 

public class GameManager : MonoBehaviour {
    
    public static GameManager instance; 
    public int votes, votesToWin;
  
    public UnityEvent OnVoteGained, OnGameOver;  
    private void Awake()
    {
        if (instance == null)
            instance = this;  
    }

    public void addVotes(int thousandVotes)
    {
        votes += thousandVotes;
        OnVoteGained.Invoke();  
    }

    public void processDeath()
    {
        OnGameOver.Invoke(); 
    }

    

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
