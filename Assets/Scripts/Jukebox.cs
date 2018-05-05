using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
public class Jukebox : MonoBehaviour {
     static Jukebox jukeboxInstance;
    void Awake()
    {
        DontDestroyOnLoad(this);

        if (jukeboxInstance == null)
        {
            jukeboxInstance = this;
        }
        else
        {
            DestroyObject(gameObject);
        }
    }
}
