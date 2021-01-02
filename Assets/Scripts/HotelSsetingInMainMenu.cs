using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HotelSsetingInMainMenu : MonoBehaviour
{
    [SerializeField] private Slider _chanceFood;
    [SerializeField] private Slider _chanceStress;
    [SerializeField] private Slider _countRoom;
    [SerializeField] private Slider _countSpy;
    [SerializeField] private Slider _countVent;
    [SerializeField] private Toggle _useIt;
    [SerializeField] private TextMeshProUGUI _countRoomText;
    [SerializeField] private TextMeshProUGUI _countSpyText;
    [SerializeField] private TextMeshProUGUI _countVentText;

    private void Update()
    {
        _countRoomText.text = _countRoom.value.ToString();
        _countSpyText.text = _countSpy.value.ToString();
    }

    public void SetPrecentFood(float value)
    {
        GlobalSetting.PrecentChanceSpawnFoodItemInRoom = System.Convert.ToInt32(value);
        Debug.Log(GlobalSetting.PrecentChanceSpawnFoodItemInRoom);
    }
    public void SetPrecentStress(float value)
    {
        GlobalSetting.PrecentChanceSpawnStreesItemInRoom = System.Convert.ToInt32(value);
        Debug.Log(GlobalSetting.PrecentChanceSpawnStreesItemInRoom);
    }
    public void SetCountRoom(float value)
    {
        GlobalSetting.CountRoomInHotel = System.Convert.ToInt32(value);
        _countRoomText.text = GlobalSetting.CountRoomInHotel.ToString();
        Debug.Log(GlobalSetting.CountRoomInHotel);
    }
    public void SetCountAgent(float value)
    {
        GlobalSetting.CountAgentInHotel = System.Convert.ToInt32(value);
        _countSpyText.text = GlobalSetting.CountAgentInHotel.ToString();
        Debug.Log(GlobalSetting.CountAgentInHotel);
    }
    public void SetCountVent(float value)
    {
        GlobalSetting.CountVentTrasition = System.Convert.ToInt32(value);
        _countVentText.text = GlobalSetting.CountVentTrasition.ToString();
        Debug.Log(GlobalSetting.CountVentTrasition);
    }
    public void SetUseIt(bool value)
    {
        GlobalSetting.UseIt = value;
        Debug.Log(GlobalSetting.UseIt);
    }
}
