using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyMenuStuff : MonoBehaviour
{
    static DontDestroyMenuStuff instance;
    // Start is called before the first frame update
    void Awake()
    {
            if (instance != null)
            {
                Destroy(gameObject);
            }
            else
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
    }

    private void Update()
    {
        if (!SceneManager.GetActiveScene().name.Equals("MainMenu") && !SceneManager.GetActiveScene().name.Equals("HowToPlay"))
        {
            Destroy(this.gameObject);
        }
    }
}
