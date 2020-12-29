using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField] private Door[] _doors;
    [SerializeField] private Ventelation[] _vents;
    [SerializeField] private TypeRoom _typeRoom;
    private int _minRoomNeiberhood, _maxRoomNeiberhood;
    private int SizeX, SizeZ;
    [SerializeField] private TypeRoom[] _preferredNextRoom;

    private int _correctCountNieberhood;

    public Ventelation[] Vents => _vents;

    private void Start()
    {
        _correctCountNieberhood = Random.Range(0, _maxRoomNeiberhood+1);
    }
    
    public int FreeDoor { 
        get
        {
            int countUsedDoor = 0;
            foreach (var door in _doors)
            {
                if (door.isUsed)
                    countUsedDoor++;
            }
            return _doors.Length - countUsedDoor;
        } 
    }
    public Door RandomFreeDoor
    {
        get
        {
            List<Door> _freeDoors = new List<Door>();
            foreach (var door in _doors)
            {
                if (door.isUsed == false)
                    _freeDoors.Add(door);
            }
            return _freeDoors[Random.Range(0, _freeDoors.Count)];
        }
    }
    public TypeRoom TypeOfRoom => _typeRoom;
    public TypeRoom[] PreferredNextRoom => _preferredNextRoom; 
    public void TryDisabelAllDoors()
    {
        foreach (var door in _doors)
        {
            door.TryDisabel();
        }
    }
    public void TryDisabelAllVet()
    {
        foreach (var vent in _vents)
        {
            vent.TryDisabel();
        }
    }
    public bool CheckHasCorrectDoor(Door.Direction directionOtherDoor)
    {
        List<Door> doorsWithCorrectDirection = GetAllDoorsWithOppositeDirection(directionOtherDoor);
        foreach (var door in doorsWithCorrectDirection)
        {
            if (door.isUsed == false)
                return true;
        }
        return false;
    }
    private List<Door> GetAllDoorsWithOppositeDirection(Door.Direction direction)
    {
        List<Door> doors = new List<Door>();
        foreach (var door in _doors)
        {
            switch (direction)
            {
                case Door.Direction.X_Negative:
                    if (door.Direct == Door.Direction.X_Positive)
                        doors.Add(door);
                    break;
                case Door.Direction.X_Positive:
                    if (door.Direct == Door.Direction.X_Negative)
                        doors.Add(door);
                    break;
                case Door.Direction.Z_Negative:
                    if (door.Direct == Door.Direction.Z_Positive)
                        doors.Add(door);
                    break;
                case Door.Direction.Z_Positive:
                    if (door.Direct == Door.Direction.Z_Negative)
                        doors.Add(door);
                    break;
            }
        }
        return doors;
    }
    public void JoinWithOtherRoomByDoor(Door doorOfOtherRoom)
    {
        List<Door> correctDoor = GetAllDoorsWithOppositeDirection(doorOfOtherRoom.Direct);
        Door freeOurDoor = null;
        foreach (var door in correctDoor)
        {
            if (door.isUsed == false)
            {
                freeOurDoor = door;
                break;
            }
        }
        if (freeOurDoor == null)
            throw new System.Exception("Двери почему то нет :(");
        freeOurDoor?.JoinMe(doorOfOtherRoom);
        doorOfOtherRoom.JoinMe(freeOurDoor);
    }
    public enum TypeRoom
    {
        corridore, bathroom, kitchen, bedroom, storage, livingRoom
    }
}
