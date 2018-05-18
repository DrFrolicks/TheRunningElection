using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEditor; 

public class ApplicationManager : MonoBehaviour {
    public static ApplicationManager instance;

    public float ESCQuitReqHoldDuration;

    public GameObject pauseScreen;  

    [HideInInspector]
    public float ESCHoldDuration; 

    public bool gameIsPaused;


    private void Update()
    {
        if (Input.GetButtonUp("Cancel"))
        {
            if (GameManager.instance.deathScreen.activeSelf)
            {
                loadScene(0); //back to menu 
            } else
            {
                //togglePause();
                ESCHoldDuration = 0;
            }
        }

        if (Input.GetButton("Cancel"))
        {
            ESCHoldDuration += Time.deltaTime;
            if (ESCHoldDuration >= ESCQuitReqHoldDuration)
            {
                Application.Quit();
            }
        }
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            loadScene(0);
        }

        if (SceneManager.GetActiveScene().buildIndex != 0 && GameManager.instance.deathScreen.activeSelf && Input.GetButtonDown("Fire1"))
        {
            reloadCurrentScene();  
        }

        if (!mouseOnScreen() && !Paused)
            Paused = true;
        if (mouseOnScreen() && Paused)
            Paused = false;  
    }

    public bool mouseOnScreen()
    {
#if UNITY_EDITOR
        if (Input.mousePosition.x == 0 || Input.mousePosition.y == 0 || Input.mousePosition.x >= Handles.GetMainGameViewSize().x - 1 || Input.mousePosition.y >= Handles.GetMainGameViewSize().y - 1)
        {
            return false;
        }
#else
        if (Input.mousePosition.x == 0 || Input.mousePosition.y == 0 || Input.mousePosition.x >= Screen.width - 1 || Input.mousePosition.y >= Screen.height - 1) {
        return false;
        }
#endif
        else
        {
            return true;
        }
    }
        private void Awake()
    {
        if (instance == null)
            instance = this;
    }

        public void togglePause()
    {
        Paused = !Paused;
    }

    public void reloadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
    }
    public void loadScene(int i)
    {
        SceneManager.LoadScene(i); 
    }



    public void quitGame()
    {
        Application.Quit();
    }

    public bool Paused
    {
        get
        {
            return gameIsPaused;
        }

        set
        {
            if (value == true && gameIsPaused == false)
            {
                Time.timeScale = 0f;
                pauseScreen.SetActive(true); 
            }
            if (value == false && gameIsPaused == true)
            {
                Time.timeScale = 1f;
                pauseScreen.SetActive(false);  
            }
            gameIsPaused = value;
        }
    }
}
