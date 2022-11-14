using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;


public class SceneLoader : MonoBehaviour
{
    public GameObject loadingscreen;
    public Slider loadingBar;
    // Start is called before the first frame update
    public void LoadScene(string levelname)
    {
        StartCoroutine(LoadSceneAsynchronously(levelname));
    }
    
    IEnumerator LoadSceneAsynchronously(string levelname)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(levelname);
        loadingscreen.SetActive(true);
        while (!operation.isDone)
        {
            loadingBar.value = operation.progress;
            yield return null;
        }
    }
}
