using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  

public class VoteDisplay : MonoBehaviour {

	public void updateVoteDisplay()
    {
        GetComponent<Text>().text = "" + GameManager.instance.votes; 
    }
}
