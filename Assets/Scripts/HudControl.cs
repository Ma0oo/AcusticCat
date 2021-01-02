using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class HudControl : MonoBehaviour
{
    [SerializeField] private Slider _foodBar;
    [SerializeField] private Slider _stressBar;
    [SerializeField] private TextMeshProUGUI _camerasText;
    [SerializeField] private TextMeshProUGUI _idRoom;
    [SerializeField] private GameObject _panelGameOVerFalse;
    [SerializeField] private GameObject _panelGameOverWin;
    [SerializeField] private TextMeshProUGUI _textResultGameOverFalse;
    [SerializeField] private TextMeshProUGUI _textAgetns;

    private int _countCamerasInRoom = 2;
    private int _countAgentOnMap;
    private int _countLinstedAgent = 0;

    private void OnEnable()
    {
        Special.UpdateFood += OnUpdateFood;
        Special.UpdateStress += OnUpdateStress;
        ControlCameraInHotel.ActivityRoomWasChange += OnActivityRoomWasChange;
        ControlCameraInHotel.NewValueOfCountCameras += OnNewValueOfCountCameras;
        ControlCameraInHotel.NewIndexActiveCamera += OnNewIndexActiveCamera;
        Special.GameOver += OnGameOverFalse;
        GeneratorHotel.MessageWithCountAgentOnMap += OnMessageWithCountAgentOnMap;
        Agent.AgentWasListenUpdateHud += OnAgentWasListenUpdateHud;

        StartCoroutine(FirstUpdateCoutSpy());
    }
    private void OnDisable()
    {
        Special.UpdateFood -= OnUpdateFood;
        Special.UpdateStress -= OnUpdateStress; 
        ControlCameraInHotel.ActivityRoomWasChange -= OnActivityRoomWasChange;
        ControlCameraInHotel.NewValueOfCountCameras -= OnNewValueOfCountCameras;
        ControlCameraInHotel.NewIndexActiveCamera -= OnNewIndexActiveCamera;
        Special.GameOver -= OnGameOverFalse;
        GeneratorHotel.MessageWithCountAgentOnMap -= OnMessageWithCountAgentOnMap;
        Agent.AgentWasListenUpdateHud -= OnAgentWasListenUpdateHud;
    }
    private void OnDestroy()
    {
        Time.timeScale = 1;
    }

    private void OnAgentWasListenUpdateHud()
    {
        _countLinstedAgent++;
        UpdateTextAgetns();
        if (_countLinstedAgent >= _countAgentOnMap)
            GameOverWin();
    }
    private void OnMessageWithCountAgentOnMap(int count)
    {
        _countAgentOnMap = count;
    }
    private void OnGameOverFalse(string textResult)
    {
        _panelGameOVerFalse.SetActive(true);
        _textResultGameOverFalse.text = textResult;
        Time.timeScale = 0;
    }
    private void GameOverWin()
    {
        _panelGameOverWin.SetActive(true);
        GetComponent<MenuInGame>().ActiveGameMenu();
        Time.timeScale = 0;
    }
    private void UpdateTextAgetns()
    {
        _textAgetns.text = $"{_countLinstedAgent}/{_countAgentOnMap} Spies";
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

    private IEnumerator FirstUpdateCoutSpy()
    {
        yield return null;
        yield return null;
        yield return null;
        UpdateTextAgetns();
    }
}
