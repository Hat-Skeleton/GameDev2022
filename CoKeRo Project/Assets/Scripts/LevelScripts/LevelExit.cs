using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    public string levelToLoad;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            //SceneManager.LoadScene(levelToLoad);
            CameraController.instance.transform.position = new Vector3(0, 0, -10);
            PlayerController.instance.Resetplayer();
            PlayerController.instance.layerOfDungeon++;
            UIController.instance.levelsdecended.text = string.Format("Levels Descended: {0}", PlayerController.instance.layerOfDungeon);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
