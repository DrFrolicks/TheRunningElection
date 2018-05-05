using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  
[RequireComponent(typeof(Text))]
public class GameOverText : MonoBehaviour {
    public string vText;  
    public void changeToVText()
    {
        GetComponent<Text>().text = vText;  
  
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
