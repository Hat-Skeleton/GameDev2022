using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEditor;

public class PauseMenuController : MonoBehaviour
{
    // Start is called before the first frame update
    public static PauseMenuController instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    public void Resume()
    {
        PlayerController.instance.PauseState();
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        SceneManager.LoadSceneAsync("MainMenu");
        Time.timeScale = 1;
    }


}
