using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;


[RequireComponent(typeof(TransitPlaceSound))]
abstract public class TransiterPlace : MonoBehaviour
{
    static public event UnityAction<Room> ActiveRoomWasChange;
    public event UnityAction<TagCanTransit> SomethingWasTransit;
    public event UnityAction TransiterPlaceWasOpen;

    [Header("Объекты")]
    [SerializeField] protected GameObject DoorBody;
    [SerializeField] protected GameObject Doorr;
    [SerializeField] protected Transform PointExit;

    [Header("Настройки")]
    [SerializeField] protected bool IsOpen;

    [HideInInspector] public bool IsUsed => Target != null;
    [SerializeField] protected TransiterPlace Target;

    private Room _myRoom;


    public void GetRoom(Room room)
    {
        _myRoom = room;
    }
    public void Open() 
    {
        TransiterPlaceWasOpen?.Invoke();
        ConcreteOpen();
    }
    public virtual void Close() 
    { 

    }
    public virtual void ConcreteOpen() { }

    public void EnterSomething(TagCanTransit tagCanTransit)
    {
        Target.ExitSomething(tagCanTransit);
    }
    public void ExitSomething(TagCanTransit tagCanTransit)
    {
        tagCanTransit.transform.position = PointExit.position;
        tagCanTransit.transform.rotation = PointExit.rotation;
        SomethingWasTransit?.Invoke(tagCanTransit);
        ActiveRoomWasChange?.Invoke(_myRoom);
    }

    public void JoinWith(TransiterPlace target)
    {
        Target = target;
    }

    public void TryDisabel()
    {
        if (IsUsed == false)
            DisabelMe();
    }
    private void EnabelMe()
    {
        DoorBody.SetActive(true);
    }
    private void DisabelMe()
    {
        DoorBody.SetActive(false);
    }

}
