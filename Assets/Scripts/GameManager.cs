using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events; 

public class GameManager : MonoBehaviour {
    
    public static GameManager instance; 
    public int votes, votesToWin;
    public GameObject deathScreen;

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

    public void gameOver()
    {
        deathScreen.SetActive(true);
    }

    public void processDeath()
    {
        OnGameOver.Invoke(); 
    }
}
