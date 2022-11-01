using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RoomCentre : MonoBehaviour
{
    public List<GameObject> enemy = new List<GameObject>();

    public bool openWhenEnemyClear;

    public Room theRoom;

    // Start is called before the first frame update
    void Start()
    {
        if(openWhenEnemyClear)
        {
            theRoom.closeWhenEnter = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy.Count > 0 && theRoom.roomActive && openWhenEnemyClear)
        {
            for (int i = 0; i < enemy.Count; i++)
            {
                if (enemy[i] == null)
                {
                    enemy.RemoveAt(i);
                    i--;
                }
            }

            if (enemy.Count == 0)
            {
                theRoom.OpenDoors();
            }
        }
    }
}
