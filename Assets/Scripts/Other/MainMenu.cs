using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject _tutorialImage;
    [SerializeField] private GameObject _creditPanel;
    [SerializeField] private GameObject[] _creditElements;
    [SerializeField] private GameObject _setting;

    [SerializeField] private int _countIndexCreditPanel;


    public void NextCredit()
    {
        _countIndexCreditPanel++;
        if (_countIndexCreditPanel >= _creditElements.Length)
            _countIndexCreditPanel = _creditElements.Length - 1;
        TurnOnSomeCreditElement();
    }
    public void PrevCredit()
    {
        _countIndexCreditPanel--;
        if (_countIndexCreditPanel < 0)
            _countIndexCreditPanel = 0;
        TurnOnSomeCreditElement();
    }
    private void TurnOnSomeCreditElement()
    {
        for (int i = 0; i < _creditElements.Length; i++)
        {
            _creditElements[i].SetActive(i == _countIndexCreditPanel);
        }
    }
    public void TurnOnOffCredit(bool isOn)
    {
        _creditPanel.SetActive(isOn);
    }
    public void TurnOnOrOffSttengPanel()
    {
        _setting.SetActive(!_setting.activeSelf);
    }
    public void TurnOnOffTutorial(bool isOn)
    {
        _tutorialImage.SetActive(isOn);
    }
    public void Exit()
    {
        Application.Quit();
    }

    public void LoadLevel(int idLevel)
    {
        Application.LoadLevel(idLevel);
    }
}
