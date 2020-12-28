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


    [HideInInspector] public bool isUsed => _target != null;
    public Direction Direct => _direction;

    private Door _target;
    public void TryDisabel()
    {
        if (isUsed == false)
            DisabelMe();
    }
    private void Update()
    {
        if (isUsed)
        {
            Debug.DrawRay(transform.position,-transform.position+_target.transform.position,Color.yellow);
        }
    }
    public void DisabelMe()
    {
        _doorBody.SetActive(false);
    }

    public void EnabelMe()
    {
        _doorBody.SetActive(true);
    }

    public void JoinMe(Door target)
    {
        _target = target;
    }

    public enum Direction
    {
        X_Positive,
        X_Negative,
        Z_Positive,
        Z_Negative
    }
}
