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
    private CatMover _catMover;

    public Animator AnimatorCat => _animatorBodyCat;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _special = GetComponent<Special>();
        _rigidbody = GetComponent<Rigidbody>();
        _catMover = GetComponent<CatMover>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
            Move();
        if (Input.GetKeyDown(KeyCode.A))
            Rotate(true);
        if (Input.GetKeyDown(KeyCode.D))
            Rotate(false);
        if (Input.GetKeyDown(KeyCode.S))
            Idel();
    }

    public void Move()
    {
        _animatorBodyCat.SetBool("Move", true);
        _animatorBodyCat.SetBool("Rotate", false);
    }
    public void Rotate(bool isToleft)
    {
        _animatorBodyCat.SetBool("Move", false);
        _animatorBodyCat.SetBool("Rotate", true);
        if (isToleft)
            _catMover.SetDirectionRotate(CatMover.DirectionRotate.left);
        else
            _catMover.SetDirectionRotate(CatMover.DirectionRotate.right);
    }
    public void Idel()
    {
        _animatorBodyCat.SetBool("Move", false);
        _animatorBodyCat.SetBool("Rotate", false);
    }

    public void SetTriggerAnimator(string nameTrigger)
    {
        _animatorBodyCat.SetTrigger(nameTrigger);
    }
}
