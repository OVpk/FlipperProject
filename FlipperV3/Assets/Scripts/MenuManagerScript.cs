using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManagerScript : MonoBehaviour
{
    public GameObject menu;
    public bool menuOpen;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
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
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
        
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
