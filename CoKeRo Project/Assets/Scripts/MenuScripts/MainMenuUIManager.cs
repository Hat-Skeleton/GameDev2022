using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUIManager : MonoBehaviour
{
    public GameObject menucontrols;
    public GameObject howtoplaymenu;
    private bool iscontrolvisible = false;
    // Start is called before the first frame update
    public string levelOne;

    public void NewGame()
    {
        SceneManager.LoadSceneAsync(levelOne);
    }

    public void LoadControlsScene()
    {
        iscontrolvisible = !iscontrolvisible;
        howtoplaymenu.SetActive(iscontrolvisible);
        menucontrols.SetActive(!iscontrolvisible);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
