using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManagerScript : MonoBehaviour
{
    [SerializeField] private Animator pauseGIFanimator;
    [SerializeField] private GameObject menu;
    
    private bool menuOpen;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.JoystickButton9))
        {
            OpenCloseMenu();
        }
    }

    private void OpenCloseMenu()
    {
        menuOpen = !menuOpen;
        menu.SetActive(menuOpen);
        if (menuOpen)
        {
            pauseGIFanimator.Play("PauseGIFanimation");
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
    
}
