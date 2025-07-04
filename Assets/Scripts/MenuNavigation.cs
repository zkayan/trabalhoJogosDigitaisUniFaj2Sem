using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuNavigation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadMainScene()
    {
        SceneManager.LoadScene("Level1");
    }

    public void LoadVictoryScene()
    {
        SceneManager.LoadScene("End");
    }
    
    public void QuitTheGame()
    {
        Application.Quit();
    }
}
