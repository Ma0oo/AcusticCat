using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInput), typeof(Special), typeof(Rigidbody))]
public class PlayerCatAI : MonoBehaviour
{
    [SerializeField] private Animator _animatorBodyCat;

    private PlayerInput _playerInput;
    private Special _special;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _special = GetComponent<Special>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {

    }
    private void OnDisable()
    {
        
    }
}
