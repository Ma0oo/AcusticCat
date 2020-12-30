using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CatMover : MonoBehaviour
{
    [SerializeField] private float _speedMove;
    [SerializeField] private float _speedRotation;

    private Rigidbody _rigidbody;
    private bool _isMove;
    private bool _isRotate;
    private DirectionRotate _direction;
    private PlayerCatAI _playerCatAI;
    private Transform _transforMainBody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _playerCatAI = GetComponent<PlayerCatAI>();
        _transforMainBody = GetComponentInChildren<Animator>().transform;
    }

    private void FixedUpdate()
    {
        if (_playerCatAI.AnimatorCat.GetCurrentAnimatorStateInfo(0).IsName("Move"))
            MoveForward();
        if (_playerCatAI.AnimatorCat.GetCurrentAnimatorStateInfo(0).IsName("Rotate")) 
            Rotate(_direction);
    }

    public void SetDirectionRotate(DirectionRotate direction)
    {
        _direction = direction;
    }
    private void Rotate(DirectionRotate rotate)
    {
        switch (rotate) 
        {
            case DirectionRotate.left:
                RotateObject(true);
                break;
            case DirectionRotate.right:
                RotateObject(false);
                break;
        }

    }
    private void RotateObject(bool isToLeft)
    {
        _rigidbody.MoveRotation(Quaternion.Lerp(_rigidbody.rotation, GetQuaternionForRotate(isToLeft), Time.fixedDeltaTime * _speedRotation));
    }
    private Quaternion GetQuaternionForRotate(bool isToLeft)
    {
        if(isToLeft)
            return Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y - 1, transform.rotation.eulerAngles.z));
        else
            return Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + 1, transform.rotation.eulerAngles.z));
    }
    private void MoveForward()
    {
        _rigidbody.AddForce(transform.forward * _speedMove, ForceMode.Force);
    }
    public enum DirectionRotate
    {
        left, right
    }
}
