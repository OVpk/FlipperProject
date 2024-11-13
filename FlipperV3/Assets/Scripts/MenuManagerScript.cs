using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManagerScript : MonoBehaviour
{
    
    public GameObject menu;
    public bool menuOpen;
    public GameObject gameOverScreen;

    public bool isDead = false;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isDead)
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

    public void GameOver()
    {
        isDead = true;
        menu.SetActive(false);
        gameOverScreen.SetActive(true);
        Time.timeScale = 0;
    }
}
