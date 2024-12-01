using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManagerScript : MonoBehaviour
{
    
    public Animator PauseGIFanimator;
    
    public GameObject menu;
    public bool menuOpen;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.JoystickButton9))
        {
            OpenCloseMenu();
        }
    }

    public void OpenCloseMenu()
    {
        menuOpen = !menuOpen;
        menu.SetActive(menuOpen);
        if (menuOpen)
        {
            PauseGIFanimator.Play("PauseGIFanimation");
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
        
    }

    public void MainMenuReturn()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
    }

    public void ReloadScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
        Time.timeScale = 1;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
