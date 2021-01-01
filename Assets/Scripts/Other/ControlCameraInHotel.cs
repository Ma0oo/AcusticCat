using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ControlCameraInHotel : MonoBehaviour
{
    public static UnityAction<string> ActivityRoomWasChange;
    public static UnityAction<int> NewValueOfCountCameras;
    public static UnityAction<int> NewIndexActiveCamera;
    

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
        ActivityRoomWasChange?.Invoke(room.ID);
        NewValueOfCountCameras?.Invoke(_managerActivityInRoom.CountCamerasInRoom);
        NewIndexActiveCamera?.Invoke(_managerActivityInRoom.IndexActiveCamera);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            _managerActivityInRoom.NextCamera(_camera);
            NewIndexActiveCamera?.Invoke(_managerActivityInRoom.IndexActiveCamera);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _managerActivityInRoom.PrevCamera(_camera);
            NewIndexActiveCamera?.Invoke(_managerActivityInRoom.IndexActiveCamera);
        }
    }


}
