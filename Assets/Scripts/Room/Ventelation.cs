using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ventelation : MonoBehaviour, IInteractive
{
    [Header("оюъекты вентиляции")]
    [SerializeField] private GameObject _bodyVentelation;
    [SerializeField] private GameObject _doorVentelation;

    [Header("Настройки вентиляции")]
    [SerializeField] private Transform _pointExit;
    [SerializeField] private bool _isOpen;

    public bool isUsed => _target != null;

    private Ventelation _target;


    private void Update()
    {
        if (isUsed)
        {
            Debug.DrawRay(transform.position, -transform.position + _target.transform.position, Color.green);
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

    public void TryDisabel()
    {
        if (isUsed == false)
            DisabelMe();
    }
    public void DisabelMe()
    {
        _bodyVentelation.SetActive(false);
    }
    public void JoinWith(Ventelation vent)
    {
        _target = vent;
    }
    public void EnabelMe()
    {
        _bodyVentelation.SetActive(true);
    }

    public void Open()
    {
        if(_isOpen == false)
        {
            Rigidbody rbOfDoor = _doorVentelation.GetComponent<Rigidbody>();
            rbOfDoor.isKinematic = false;
            rbOfDoor.useGravity = true;
            _doorVentelation.transform.position = _doorVentelation.transform.position + _doorVentelation.transform.right * -0.3f;
            rbOfDoor.AddForce(Vector3.up*4, ForceMode.Impulse);
            _isOpen = true;
            Destroy(rbOfDoor.gameObject, 3);
            GetComponent<BoxCollider>().enabled = false;
        }
    }

    public string GetNameTrigerAnimator()
    {
        return "TryOpen";
    }

    public void Action()
    {
        Open();
    }

}
