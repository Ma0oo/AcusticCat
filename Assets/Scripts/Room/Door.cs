using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

public class Door : MonoBehaviour, IInteractive
{
    public UnityAction<TagCanTransit> SomethingWasTransit;

    [Header("Объекты двери")]
    [SerializeField] private GameObject _doorBody;
    [SerializeField] private GameObject _door;

    [Header("Настройки двери")]
    [SerializeField] private Direction _direction;
    [SerializeField] private Transform _pointExit;
    [SerializeField] private bool _isOpen;

    [Header("На удаление")]
    [SerializeField] private bool _triger;

    [HideInInspector] public bool isUsed => _target != null;
    public Direction Direct => _direction;
    private float _angelOfclose;
    [SerializeField] private Door _target;


    private void Start()
    {
        _angelOfclose = transform.eulerAngles.y;
    }
    private void Update()
    {
        if (isUsed)
        {
            Debug.DrawRay(transform.position,-transform.position+_target.transform.position,Color.yellow);
        }
        if (_triger)
        {
            if (_isOpen)
                Close();
            else
                Open();
            _triger = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out ActionModule actionModeul))
        {
            actionModeul.TakeActiveItem(this);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out ActionModule actionModeul))
        {
            actionModeul.RemoveActiveItem();
        }
    }

    public void TryDisabel()
    {
        if (isUsed == false)
            DisabelMe();
    }
    public void JoinMe(Door target)
    {
        _target = target;
    }
    public void Open()
    {
        if(_isOpen == false) 
        {
            float _angelOfOpen = _door.transform.eulerAngles.y - Random.Range(50, 80);
            _door.transform.DORotate(new Vector3(0, _angelOfOpen, 0), 2);
            _isOpen = true;
            _target?.Open();
            GetComponent<BoxCollider>().enabled = false;
        }
    }
    public void Close()
    {
        if (_isOpen)
        {
            _door.transform.DORotate(new Vector3(0, _angelOfclose, 0), 2);
            _isOpen = false;
            _target?.Close();
            GetComponent<BoxCollider>().enabled = true;
        }
    }
    public void EnterSomething(TagCanTransit tagCanTransit)
    {
        _target.ExitSomething(tagCanTransit);
    }
    public void ExitSomething(TagCanTransit tagCanTransit)
    {
        tagCanTransit.transform.position = _pointExit.position;
        tagCanTransit.transform.rotation = _pointExit.rotation;
        SomethingWasTransit?.Invoke(tagCanTransit);
    }

    private void EnabelMe()
    {
        _doorBody.SetActive(true);
    }
    private void DisabelMe()
    {
        _doorBody.SetActive(false);
    }

    public string GetNameTrigerAnimator()
    {
        Debug.Log("Возврашаю имя тригера");
        return "TryOpen";
    }
    public void Action()
    {
        Debug.Log("Я дверь и я отвкрываюсь");
        Open();
    }

    public enum Direction
    {
        X_Positive,
        X_Negative,
        Z_Positive,
        Z_Negative
    }
}
