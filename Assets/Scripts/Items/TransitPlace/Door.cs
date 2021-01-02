using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

public class Door : TransiterPlace, IInteractive
{
    [Header("Настройки двери")]
    [SerializeField] private Direction _direction;

    public Direction Direct => _direction;
    private float _angelOfclose;

    private void Start()
    {
        _angelOfclose = transform.eulerAngles.y;
    }
    private void Update()
    {
        if (IsUsed)
        {
            Debug.DrawRay(transform.position,-transform.position+Target.transform.position,Color.yellow);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out ActionModule actionModeul))
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


    public void JoinMe(TransiterPlace target)
    {
        Target = target;
    }
    
    public override void Close()
    {
        if (IsOpen)
        {
            Doorr.transform.DORotate(new Vector3(0, _angelOfclose, 0), 2);
            IsOpen = false;
            Target?.Close();
            GetComponent<BoxCollider>().enabled = true;
        }
    }
    public override void ConcreteOpen()
    {
        if (IsOpen == false)
        {
            float _angelOfOpen = Doorr.transform.eulerAngles.y - Random.Range(50, 80);
            Doorr.transform.DORotate(new Vector3(0, _angelOfOpen, 0), 0.8f);
            IsOpen = true;
            Target?.Open();
            GetComponent<BoxCollider>().enabled = false;
        }
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
