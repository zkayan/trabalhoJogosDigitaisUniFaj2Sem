using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    public bool quitGameButtonVisible = false;
    public GameObject quitGameButton;

    // Start is called before the first frame update
    void Start()
    {
        quitGameButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Cursor.lockState == CursorLockMode.Locked) {
                Cursor.lockState = CursorLockMode.None;
            } else
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
            Cursor.visible = !Cursor.visible;
            quitGameButton.SetActive(!quitGameButton.activeSelf);
            quitGameButtonVisible = !quitGameButtonVisible;
        }

    }

    public void Quit()
    {
        Application.Quit();
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
