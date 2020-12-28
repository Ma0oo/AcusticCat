using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [Header("Объекты двери")]
    [SerializeField] private GameObject _doorBody;
    [SerializeField] private GameObject _door;

    [Header("Настройки двери")]
    [SerializeField] private Direction _direction;
    [SerializeField] private Transform _pointExit;
    [SerializeField] private bool isOpen;

    [HideInInspector]
    public bool isUsed => _target != null;

    private Door _target;

    public enum Direction
    {
        X_Positive,
        X_Negative,
        Z_Positive,
        Z_Negative
    }
}
