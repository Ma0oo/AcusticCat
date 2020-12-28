using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorHotel : MonoBehaviour
{
    [SerializeField] private Room[] prefabsRoom;
    [SerializeField] private Transform parentOfRoom;
    [SerializeField] private int _countRoomInHotel;

    private List<Room> roomWithFreeDoor = new List<Room>();
    private List<Room> roomWithBusyDoor = new List<Room>();

    private void Start()
    {
        GenerateHotel();
    }

    private void GenerateHotel()
    {
        roomWithFreeDoor.Add(InstantieteRoom(GetRandomRoomByType(Room.TypeRoom.storage)));

        while (roomWithBusyDoor.Count + roomWithFreeDoor.Count <= _countRoomInHotel)
        {
            CheckListFreeAndBuseDoor();
            Room choiceRoom = GetRandomRoomWithFreeDoor();
            Door doorOfChoiceRoom = choiceRoom.RandomFreeDoor;
            Room nextRoom = FindRoomWithCorrectDoor(choiceRoom.PreferredNextRoom, doorOfChoiceRoom.Direct);
            nextRoom = InstantieteRoom(nextRoom);
            nextRoom.JoinWithOtherRoom(doorOfChoiceRoom);
            roomWithFreeDoor.Add(nextRoom);
            CheckListFreeAndBuseDoor();

            int free = roomWithFreeDoor.Count;
            int busy = roomWithBusyDoor.Count;
            int sum = free + busy;
            Debug.Log($"{free} + {busy} = {sum} < {_countRoomInHotel} : {sum < _countRoomInHotel}");
        }

        foreach (var item in roomWithFreeDoor)
        {
            item.TryDisabelAllDoors();
        }
        foreach (var item in roomWithBusyDoor)
        {
            item.TryDisabelAllDoors();
        }
    }
    private void CheckListFreeAndBuseDoor()
    {
        for (int i = 0; i < roomWithFreeDoor.Count; i++)
        {
            if(roomWithFreeDoor[i].FreeDoor <= 0)
            {
                roomWithBusyDoor.Add(roomWithFreeDoor[i]);
                roomWithFreeDoor.RemoveAt(i);
                i = 0;
            }
        }
    }
    private Room FindRoomWithCorrectDoor(Room.TypeRoom[] correctTypesRoom, Door.Direction direction)
    {
        while (true)
        {
            Room nextRoom = GetRandomRoomByTypes(correctTypesRoom);
            if (nextRoom.CheckHasCorrectDoor(direction))
                return nextRoom;
        }
    }
    private Room GetRandomRoomWithFreeDoor()
    {
        return roomWithFreeDoor[Random.Range(0, roomWithFreeDoor.Count)];
    }
    private Room GetRandomRoom()
    {
        Room room = prefabsRoom[Random.Range(0, prefabsRoom.Length)];
        while (room.TypeOfRoom == Room.TypeRoom.storage)
            room = prefabsRoom[Random.Range(0, prefabsRoom.Length)];

        return room;
    }
    private Room GetRandomRoomByType(Room.TypeRoom needfulTypeRoom)
    {
        Room room = prefabsRoom[Random.Range(0, prefabsRoom.Length)];
        while (room.TypeOfRoom != needfulTypeRoom)
            room = prefabsRoom[Random.Range(0, prefabsRoom.Length)];

        return room;
    }
    private Room GetRandomRoomByTypes(Room.TypeRoom[] typesRoom)
    {
        return GetRandomRoomByType(typesRoom[Random.Range(0, typesRoom.Length)]);
    }
    private Room InstantieteRoom(Room room)
    {
        return Instantiate(room, new Vector3(0 + (30 * (roomWithBusyDoor.Count + roomWithFreeDoor.Count)), 0, 0), room.transform.rotation, parentOfRoom);    
    }
}
