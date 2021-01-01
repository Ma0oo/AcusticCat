using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HudControl : MonoBehaviour
{
    [SerializeField] private Slider _foodBar;
    [SerializeField] private Slider _stressBar;
    [SerializeField] private TextMeshProUGUI _camerasText;
    [SerializeField] private TextMeshProUGUI _idRoom;
    [SerializeField] private GameObject _panelGameOVerFalse;
    [SerializeField] private TextMeshProUGUI _textResultGameOverFalse;

    private int _countCamerasInRoom = 2;

    private void OnEnable()
    {
        Special.UpdateFood += OnUpdateFood;
        Special.UpdateStress += OnUpdateStress;
        ControlCameraInHotel.ActivityRoomWasChange += OnActivityRoomWasChange;
        ControlCameraInHotel.NewValueOfCountCameras += OnNewValueOfCountCameras;
        ControlCameraInHotel.NewIndexActiveCamera += OnNewIndexActiveCamera;
        Special.GameOver += OnGameOverFalse;
    }
    private void OnDisable()
    {
        Special.UpdateFood -= OnUpdateFood;
        Special.UpdateStress -= OnUpdateStress; 
        ControlCameraInHotel.ActivityRoomWasChange -= OnActivityRoomWasChange;
        ControlCameraInHotel.NewValueOfCountCameras -= OnNewValueOfCountCameras;
        ControlCameraInHotel.NewIndexActiveCamera -= OnNewIndexActiveCamera;
        Special.GameOver -= OnGameOverFalse;
    }
    private void OnDestroy()
    {
        Time.timeScale = 1;
    }
    private void OnGameOverFalse(string textResult)
    {
        _panelGameOVerFalse.SetActive(true);
        _textResultGameOverFalse.text = textResult;
        Time.timeScale = 0.005f;
    }
    private void OnNewIndexActiveCamera(int indexActiveCameras)
    {
        _camerasText.text = $"{indexActiveCameras}/{_countCamerasInRoom}";
    }
    private void OnNewValueOfCountCameras(int countCameras)
    {
        _countCamerasInRoom = countCameras;
    }
    private void OnActivityRoomWasChange(string idRoom)
    {
        _idRoom.text = idRoom;
    }
    private void OnUpdateFood(float value)
    {
        UpdateBar(Bar.Food, value);
    }
    private void OnUpdateStress(float value)
    {
        UpdateBar(Bar.Stress, value);
    }
    private void UpdateBar(Bar bar, float value)
    {
        if (bar == Bar.Food)
            _foodBar.value = value;
        if (bar == Bar.Stress)
            _stressBar.value = value;
    }
    private enum Bar
    {
        Food, Stress
    }
}
