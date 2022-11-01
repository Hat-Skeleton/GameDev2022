using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelGen : MonoBehaviour
{
    public GameObject layoutRoom;
    public Color startColour, endColour;

    public int distanceToEnd;

    public Transform genPoint;

    public float xOffset = 18f, yOffset = 10;

    public LayerMask whatIsRoom;

    public enum Direction
    {
        up, right, down, left
    };

    public Direction selectedDirection;

    private GameObject endRoom;

    private List<GameObject> layoutRoomObjects = new List<GameObject>();

    public RoomPrefabs rooms;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(layoutRoom, genPoint.position, genPoint.rotation).GetComponent<SpriteRenderer>().color = startColour;
        selectedDirection = (Direction)Random.Range(0, 4);
        MoveGenPoint();

        for(int i = 0; i < distanceToEnd; i++)
        {
            GameObject newRoom = Instantiate(layoutRoom, genPoint.position, genPoint.rotation);

            layoutRoomObjects.Add(newRoom);

            if (i + 1 == distanceToEnd)
            {
                newRoom.GetComponent<SpriteRenderer>().color = endColour;
                layoutRoomObjects.RemoveAt(layoutRoomObjects.Count - 1);
                endRoom = newRoom;
            }

            selectedDirection = (Direction)Random.Range(0, 4);
            MoveGenPoint();
            while(Physics2D.OverlapCircle(genPoint.position, .2f, whatIsRoom))
            {
                MoveGenPoint();
            }
        }
        //room outlines
        CreateRoomOutline(Vector3.zero);
        foreach(GameObject room in layoutRoomObjects)
        {
            CreateRoomOutline(room.transform.position);
        }
        CreateRoomOutline(endRoom.transform.position);

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void MoveGenPoint()
    {
        switch (selectedDirection)
        {
            case Direction.up:
                genPoint.position += new Vector3(0f, yOffset, 0f);
                break;
            case Direction.right:
                genPoint.position += new Vector3(xOffset, 0f, 0f);
                break;
            case Direction.down:
                genPoint.position += new Vector3(0f, -yOffset, 0f);
                break;
            case Direction.left:
                genPoint.position += new Vector3(-xOffset, 0f, 0f);
                break;
        }
    }

    public void CreateRoomOutline(Vector3 roomPostion)
    {
        bool roomAbove = Physics2D.OverlapCircle(roomPostion + new Vector3(0f, yOffset, 0f), .2f, whatIsRoom);
        bool roomBelow = Physics2D.OverlapCircle(roomPostion + new Vector3(0f, -yOffset, 0f), .2f, whatIsRoom);
        bool roomLeft = Physics2D.OverlapCircle(roomPostion + new Vector3(-xOffset, 0f, 0f), .2f, whatIsRoom);
        bool roomRight = Physics2D.OverlapCircle(roomPostion + new Vector3(xOffset, 0f, 0f), .2f, whatIsRoom);
    }
}

[System.Serializable]
public class RoomPrefabs
{
    public GameObject singleUp, singleDown, singleLeft, singleRight, doubleLeftRight, doubleUpDown, doubleLeftUP, doubleRightUp, doubleLeftDown, doubleRightDown, tripleUpRightDown, tripleRightDownLeft, tripleDownLeftUp, tripleLeftUpRight, fourway;
}
