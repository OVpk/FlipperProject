using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void LoadScene(string nameOfScene)
    {
        SceneManager.LoadScene(nameOfScene);
    }
    
    public void Quit()
    {
        Application.Quit();
    }
}
