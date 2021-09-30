using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuScript : MonoBehaviour
{
    public bool botaoSairVisivel = false;
    public GameObject botaoSair;

    // Start is called before the first frame update
    void Start()
    {
        botaoSair.SetActive(false);
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
            botaoSair.SetActive(!botaoSair.activeSelf);
            botaoSairVisivel = !botaoSairVisivel;
        }
    }

    public void quit()
    {
        Application.Quit();
    }

}
