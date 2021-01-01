using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInput), typeof(Special), typeof(Rigidbody))]
[RequireComponent(typeof(SoundManagerPlayerCat))]
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

    private void OnEnable()
    {
        _playerInput.DownKeyIdel += Idel;
        _playerInput.DownKeyMoveForward += Move;
        _playerInput.DownKeyRotateLeft += RotateLeft;
        _playerInput.DownKeyRotateRight += RotateRight;
    }
    private void OnDisable()
    {
        _playerInput.DownKeyIdel -= Idel;
        _playerInput.DownKeyMoveForward -= Move;
        _playerInput.DownKeyRotateLeft -= RotateLeft;
        _playerInput.DownKeyRotateRight -= RotateRight;
    }

    private void RotateLeft()
    {
        Rotate(true);
    }
    private void RotateRight()
    {
        Rotate(false);
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
