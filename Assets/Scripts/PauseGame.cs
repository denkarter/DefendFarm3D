using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public GameObject pauseMenu;
    private bool isPaused = false;
    
    private void Start()
    {
        pauseMenu.SetActive(false);
    }
    
    public void TogglePause()
    {
        if (isPaused)
        {
            GameResume();
        }
        else
        {
            GamePause();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }


    public void GamePause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;
        AudioListener.pause = true; 
    }

    public void GameResume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1.0f;
        isPaused = false;
        AudioListener.pause = false; 
    }

    public void QuitGame()
    {
        
            Application.Quit();
        
    }
}
