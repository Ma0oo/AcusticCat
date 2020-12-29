using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CatMover : MonoBehaviour
{
    [SerializeField] private float _speedMove;

    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    public void Update()
    {
        MoveForward();
    }

    private void MoveForward()
    {
        _rigidbody.AddForce(transform.forward * _speedMove, ForceMode.Force);
    }
}
