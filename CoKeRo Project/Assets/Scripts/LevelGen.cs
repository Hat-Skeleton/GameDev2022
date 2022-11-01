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

    private List<GameObject> genOutlines = new List<GameObject>();

    public RoomCentre centerStart, centerEnd;
    public RoomCentre[] centerAry;

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

        foreach(GameObject outline in genOutlines)
        {
            int centerSelect = Random.Range(0, centerAry.Length);

            Instantiate(centerAry[centerSelect], outline.transform.position, transform.rotation).theRoom = outline.GetComponent<Room>();
        }

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

        int directionCount = 0;
        if (roomAbove)
        {
            directionCount += 1;
        }
        if (roomBelow)
        {
            directionCount += 1;
        }
        if (roomLeft)
        {
            directionCount += 1;
        }
        if (roomRight)
        {
            directionCount += 1;
        }

        switch (directionCount)
        {
            case 0:
                Debug.LogError("No room");
                break;
            case 1:
                if(roomAbove)
                {
                    genOutlines.Add(Instantiate(rooms.singleUp, roomPostion, transform.rotation));
                }
                if (roomBelow)
                {
                    genOutlines.Add(Instantiate(rooms.singleDown, roomPostion, transform.rotation));
                }
                if (roomLeft)
                {
                    genOutlines.Add(Instantiate(rooms.singleLeft, roomPostion, transform.rotation));
                }
                if (roomRight)
                {
                    genOutlines.Add(Instantiate(rooms.singleRight, roomPostion, transform.rotation));
                }
                break;
            case 2:
                if (roomAbove && roomBelow)
                {
                    genOutlines.Add(Instantiate(rooms.doubleUpDown, roomPostion, transform.rotation));
                }
                if (roomAbove && roomRight)
                {
                    genOutlines.Add(Instantiate(rooms.doubleRightUp, roomPostion, transform.rotation));
                }
                if (roomAbove && roomLeft)
                {
                    genOutlines.Add(Instantiate(rooms.doubleLeftUP, roomPostion, transform.rotation));
                }
                if (roomBelow && roomRight)
                {
                    genOutlines.Add(Instantiate(rooms.doubleRightDown, roomPostion, transform.rotation));
                }
                if (roomBelow && roomLeft)
                {
                    genOutlines.Add(Instantiate(rooms.doubleLeftDown, roomPostion, transform.rotation));
                }
                if (roomLeft && roomRight)
                {
                    genOutlines.Add(Instantiate(rooms.doubleLeftRight, roomPostion, transform.rotation));
                }
                break;
            case 3:
                if (roomAbove && roomBelow && roomLeft)
                {
                    genOutlines.Add(Instantiate(rooms.tripleDownLeftUp, roomPostion, transform.rotation));
                }
                if (roomAbove && roomBelow && roomRight)
                {
                    genOutlines.Add(Instantiate(rooms.tripleUpRightDown, roomPostion, transform.rotation));
                }
                if (roomAbove && roomRight && roomLeft)
                {
                    genOutlines.Add(Instantiate(rooms.tripleLeftUpRight, roomPostion, transform.rotation));
                }
                if (roomRight && roomBelow && roomLeft)
                {
                    genOutlines.Add(Instantiate(rooms.tripleRightDownLeft, roomPostion, transform.rotation));
                }

                break;
            case 4:
                genOutlines.Add(Instantiate(rooms.fourway, roomPostion, transform.rotation));
                break;
        }
    }
}

[System.Serializable]
public class RoomPrefabs
{
    public GameObject singleUp, singleDown, singleLeft, singleRight, doubleLeftRight, doubleUpDown, doubleLeftUP, doubleRightUp, doubleLeftDown, doubleRightDown, tripleUpRightDown, tripleRightDownLeft, tripleDownLeftUp, tripleLeftUpRight, fourway;
}
