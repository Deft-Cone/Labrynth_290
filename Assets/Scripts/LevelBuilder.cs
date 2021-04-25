using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBuilder : MonoBehaviour
{
    public Room startRoomPrefab, endRoomPrefab;
    public List<Room> roomPrefabs = new List<Room>();
    public Vector2 iterationRange = new Vector2 (3, 10);

    List<Doorway> availableDoorways = new List<Doorway>();

    StartRoom startRoom;
    EndRoom endRoom;
    List<Room> placedRooms = new List<Room> ();

    LayerMask roomLayerMask;

    void Start()
    {
        roomLayerMask = LayerMask.GetMask("Room");
        StartCoroutine("GenerateLevel");
    }

    IEnumerator GenerateLevel()
    {
        WaitForSeconds startup = new WaitForSeconds (1);
        WaitForFixedUpdate interval = new WaitForFixedUpdate ();
        yield return startup;

        // Place start room
        PlaceStartRoom();
        yield return interval;

        // Random iterations
        int iterations = Random.Range((int)iterationRange.x, (int)iterationRange.y);

        for(int i = 0; i < iterations; i++)
        {
            // Place random room from list
            PlaceRoom();
            yield return interval;
        }

        // Place end room
        PlaceEndRoom();
        yield return interval;

        // Level Generation Finished
        Debug.Log("Level Generation Finished");

        yield return new WaitForSeconds (3);
        ResetLevelGenerator();
    }

    void PlaceStartRoom()
    {
        // Instantiate start room
        startRoom = Instantiate(startRoomPrefab) as StartRoom;
        startRoom.transform.parent = this.transform;

        // Get doorways from current room and add them randomly to the list of avaliable doorways
        AddDoorwaysToList(startRoom, ref availableDoorways);

        // Position room
        startRoom.transform.position = Vector3.zero;
        startRoom.transform.rotation = Quaternion.identity;
    }

    void AddDoorwaysToList(Room room, ref List<Doorway> list)
    {
        foreach(Doorway doorway in room.doorways)
        {
            int r = Random.Range (0, list.Count);
            list.Insert(r, doorway);
        }
    }

    void PlaceRoom()
    {
        Debug.Log("Place random room from list");
    }

    void PlaceEndRoom()
    {
        Debug.Log("Place end room");
    }

    void ResetLevelGenerator()
    {
        Debug.LogError("Reset level generator");

        StopCoroutine ("GenerateLevel");
        
        // Delete all rooms
        if(startRoom)
        {
            Destroy (startRoom.gameObject);
        }

        if (endRoom)
        {
            Destroy (endRoom.gameObject);
        }

        foreach(Room room in placedRooms)
        {
            Destroy (room.gameObject);
        }

        // Clear Lists
        placedRooms.Clear();
        availableDoorways.Clear();
        
        // Reset coroutine
        StartCoroutine ("GenerateLevel");
    }
}
