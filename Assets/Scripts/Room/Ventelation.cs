using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ventelation : MonoBehaviour
{
    [Header("оюъекты вентиляции")]
    [SerializeField] private GameObject _bodyVentelation;
    [SerializeField] private GameObject _doorVentelation;

    [Header("Настройки вентиляции")]
    [SerializeField] private Transform _pointExit;
    [SerializeField] private bool isOpen;

    public bool isUsed => _target != null;

    private Ventelation _target;

    public void DisabelMe()
    {
        _bodyVentelation.SetActive(false);
    }

    public void EnabelMe()
    {
        _bodyVentelation.SetActive(true);
    }
}
