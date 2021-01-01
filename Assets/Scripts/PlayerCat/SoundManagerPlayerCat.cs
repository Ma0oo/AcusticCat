using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
public class SoundManagerPlayerCat : MonoBehaviour
{
    [Header("Источники")]
    [SerializeField] private AudioSource[] _source;
    [SerializeField] private AudioSource _sorceBip;

    [Header("Звуки")]
    [SerializeField] private AudioClip _step;
    [SerializeField] private AudioClip _meow;
    [SerializeField] private AudioClip _bipMove;
    [SerializeField] private AudioClip _bipRotateLeft;
    [SerializeField] private AudioClip _bipRotateRight;
    [SerializeField] private AudioClip _bipIdel;
    [SerializeField] private AudioClip _bipInteract;
    [SerializeField] private AudioClip _eat;

    private PlayerInput _playerInput;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        foreach (var source in _source)
        {
            source.playOnAwake = false;
        }
    }
    private void OnEnable()
    {
        _playerInput.DownKeyIdel += OnIdel;
        _playerInput.DownKeyMoveForward += OnMove;
        _playerInput.DownKeyRotateLeft += OnRotateLeft;
        _playerInput.DownKeyRotateRight += OnRotateRight;
        _playerInput.DownKeyInterect += OnInterect;
    }
    private void OnDisable()
    {
        _playerInput.DownKeyIdel -= OnIdel;
        _playerInput.DownKeyMoveForward -= OnMove;
        _playerInput.DownKeyRotateLeft -= OnRotateLeft;
        _playerInput.DownKeyRotateRight -= OnRotateRight;
        _playerInput.DownKeyInterect -= OnInterect;
    }
    public void StopSound(int indexSource)
    {
        GetSourceById(indexSource).Stop();
    }
    public void PlaySound(int indexSource, TypeSound typeSound, bool isLoop)
    {
        AudioSource source = GetSourceById(indexSource);
        source.loop = isLoop;
        source.clip = GetAudioClip(typeSound);
        source.Play();
    }
    public void PlayBip(TypeSound typeSound)
    {
        _sorceBip.clip = GetAudioClip(typeSound);
        _sorceBip.Play();
    }
    public void StopallSound()
    {
        foreach (var source in _source)
        {
            source.Stop();
        }
    }



    private void OnMove()
    {
        PlayBip(TypeSound.BipMove);
    }
    private void OnRotateLeft()
    {
        PlayBip(TypeSound.BipRotateLeft);
    }
    private void OnRotateRight()
    {
        PlayBip(TypeSound.BipRotateRight);
    }
    private void OnIdel()
    {
        PlayBip(TypeSound.BipIdel);
    }
    private void OnInterect()
    {
        PlayBip(TypeSound.BipInteract);
    }
    private AudioSource GetSourceById(int id)
    {
        if (id < 0)
            id = 0;
        if (id >= _source.Length)
            id = _source.Length - 1;

        return _source[id];
    }
    private AudioClip GetAudioClip(TypeSound typeSound)
    {
        switch (typeSound)
        {
            case TypeSound.Meow:
                return _meow;
            case TypeSound.Step:
                return _step;
            case TypeSound.BipMove:
                return _bipMove;
            case TypeSound.BipRotateLeft:
                return _bipRotateLeft;
            case TypeSound.BipRotateRight:
                return _bipRotateRight;
            case TypeSound.BipIdel:
                return _bipIdel;
            case TypeSound.BipInteract:
                return _bipInteract;
            case TypeSound.Eating:
                return _eat;
            default:
                throw new System.Exception("Ты мне че скормил?!?!?");
        }
    }
    public enum TypeSound
    {
        Step, Meow, BipMove, BipRotateLeft, BipRotateRight, BipIdel, BipInteract, Eating
    }
}
