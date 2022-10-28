using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PauseMenuController : MonoBehaviour
{
    // Start is called before the first frame update
    public static PauseMenuController instance;

    private void Awake()
    {
        instance = this;
    }

    public void Resume()
    {
        PlayerController.instance.PauseState();
    }

    public void Quit()
    {
        Application.Quit();
    }
}
