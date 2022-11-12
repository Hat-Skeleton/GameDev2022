using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUIManager : MonoBehaviour
{
    // Start is called before the first frame update
    public string levelOne;

    public void NewGame()
    {
        SceneManager.LoadSceneAsync(levelOne);
    }

    public void LoadControlsScene()
    {
        SceneManager.LoadSceneAsync("HowToPlay");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
