using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorHotel : MonoBehaviour
{
    [SerializeField] private Room[] prefabsRoom;
    [SerializeField] private Transform parentOfRoom;
    [SerializeField] private int _countRoomInHotel;
    [SerializeField] private int _countVentTrasition;

    private List<Room> roomWithFreeDoor = new List<Room>();
    private List<Room> roomWithBusyDoor = new List<Room>();

    private List<Room> _allRooms = new List<Room>();

    private void Start()
    {
        GenerateHotel();
    }

    private void GenerateHotel()
    {
        roomWithFreeDoor.Add(InstantieteRoom(GetRandomRoomByType(Room.TypeRoom.storage)));
        _allRooms.Add(roomWithFreeDoor[0]);
        while (roomWithBusyDoor.Count + roomWithFreeDoor.Count <= _countRoomInHotel && roomWithFreeDoor.Count>0)
        {
            CheckListFreeAndBuseDoor();
            Room choiceRoom = GetRandomRoomWithFreeDoor();
            Door doorOfChoiceRoom = choiceRoom.RandomFreeDoor;
            Room nextRoom = FindRoomWithCorrectDoor(choiceRoom.PreferredNextRoom, doorOfChoiceRoom.Direct);
            nextRoom = InstantieteRoom(nextRoom);
            nextRoom.JoinWithOtherRoomByDoor(doorOfChoiceRoom);
            roomWithFreeDoor.Add(nextRoom);
            _allRooms.Add(nextRoom);
            CheckListFreeAndBuseDoor();

            int free = roomWithFreeDoor.Count;
            int busy = roomWithBusyDoor.Count;
            int sum = free + busy;
            Debug.Log($"{free} + {busy} = {sum} < {_countRoomInHotel} : {sum < _countRoomInHotel}");
        }

        CreateVetTransition(_countVentTrasition);

        DisabelDoorAndVentelation();
    }
    private void CreateVetTransition(int countTransition)
    {
        List<Ventelation> vents = GetAllVents();
        for (int i = 0; i < _countVentTrasition; i++)
        {
            if (vents.Count <= 1)
                break;

            Ventelation x = vents[Random.Range(0, vents.Count)];
            Ventelation y = vents[Random.Range(0, vents.Count)];
            while (y == x)
                y = vents[Random.Range(0, vents.Count)];

            x.JoinWith(y);
            y.JoinWith(x);
            vents.Remove(x);
            vents.Remove(y);
            Debug.Log($"Создано {i} вентиляция");
        }
    }
    private List<Ventelation> GetAllVents()
    {
        List<Ventelation> result = new List<Ventelation>();
        foreach (var room in _allRooms)
        {
            foreach (var vent in room.Vents)
            {
                result.Add(vent);
            }
        }
        return result;
    }
    private void DisabelDoorAndVentelation()
    {
        foreach (var item in _allRooms)
        {
            item.TryDisabelAllDoors();
            item.TryDisabelAllVet();
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
