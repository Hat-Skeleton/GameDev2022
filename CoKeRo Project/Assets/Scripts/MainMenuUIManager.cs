using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUIManager : MonoBehaviour
{
    // Start is called before the first frame update
    public string firstLevel;

    public void NewGame()
    {
        SceneManager.LoadSceneAsync(firstLevel);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
