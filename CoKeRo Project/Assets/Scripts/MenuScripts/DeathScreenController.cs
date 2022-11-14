using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreenController : MonoBehaviour
{
    public static DeathScreenController instance;
    public GameObject deathscreen;
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
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (deathscreen.activeInHierarchy)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                SceneManager.LoadSceneAsync("MainMenu");
                Debug.Log("Loading menu");
            }
            else if (Input.GetKey(KeyCode.R))
            {
                SceneManager.LoadSceneAsync("MainMenu");
                SceneManager.LoadSceneAsync("LevelOne");
                Debug.Log("Loading LevelOne");
            }
        }
    }
}
