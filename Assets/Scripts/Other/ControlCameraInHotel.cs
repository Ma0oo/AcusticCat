using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCameraInHotel : MonoBehaviour
{
    private ManagerActivityInRoom _managerActivityInRoom;
    private Camera _camera;

    private void Awake()
    {
        _camera = GetComponent<Camera>();   
    }
    private void OnEnable()
    {
        TransiterPlace.ActiveRoomWasChange += OnActiveRoomWasChange;
        GeneratorHotel.StorageWasCreator += OnActiveRoomWasChange;
    }
    private void OnDisable()
    {
        TransiterPlace.ActiveRoomWasChange -= OnActiveRoomWasChange;
        GeneratorHotel.StorageWasCreator -= OnActiveRoomWasChange;
    }

    private void OnActiveRoomWasChange(Room room)
    {
        _managerActivityInRoom = room.GetComponent<ManagerActivityInRoom>();
        _managerActivityInRoom.NextCamera(_camera);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
            _managerActivityInRoom.NextCamera(_camera);
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            _managerActivityInRoom.PrevCamera(_camera);
    }


}
