using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public bool closeWhenEnter; //openWhenEnemyClear;

    public GameObject[] doors;

    //public List<GameObject>  enemy = new List<GameObject>();

    [HideInInspector]
    public bool roomActive;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if(enemy.Count > 0 && roomActive && openWhenEnemyClear)
        {
            for(int i = 0; i < enemy.Count; i++)
            {
                if (enemy[i] == null)
                {
                    enemy.RemoveAt(i);
                    i--;
                }
            }

            if(enemy.Count == 0)
            {
                foreach (GameObject door in doors)
                {
                    door.SetActive(false);

                    closeWhenEnter = false;
                }
            }
        }*/
    }

    public void OpenDoors()
    {
        foreach (GameObject door in doors)
        {
            door.SetActive(false);

            closeWhenEnter = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            CameraController.instance.ChangeTarget(transform);

            if (closeWhenEnter) 
            {
                foreach(GameObject door in doors)
                {
                    door.SetActive(true);
                }
            }
            roomActive = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            roomActive = false;
        }
    }
}
