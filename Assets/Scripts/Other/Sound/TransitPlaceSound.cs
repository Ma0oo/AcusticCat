using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TransiterPlace))]
public class TransitPlaceSound : MonoBehaviour
{
    [SerializeField] private AudioSource _passiveSoundSource;
    [SerializeField] private AudioSource _activeSoundSource;

    [SerializeField] private AudioClip _openSound, _passiveSound, _stepSound;
    private TransiterPlace _transiterPlace;

    private void Awake()
    {
        _transiterPlace = GetComponent<TransiterPlace>();
        _activeSoundSource.loop = false;

        if(_passiveSound != null)
        {
            _passiveSoundSource.clip = _passiveSound;
            _passiveSoundSource.loop = true;
            _passiveSoundSource.Play();
        }
    }
    private void OnEnable()
    {
        _transiterPlace.SomethingWasTransit += OnSomethingWasTransist;
        _transiterPlace.TransiterPlaceWasOpen += OnTranitPlaceWasOpen;
    }
    private void OnDisable()
    {
        _transiterPlace.SomethingWasTransit -= OnSomethingWasTransist;
        _transiterPlace.TransiterPlaceWasOpen -= OnTranitPlaceWasOpen;
    }

    private void OnTranitPlaceWasOpen()
    {
        Debug.Log("Проиграл ли я звук? - " + transform.name);
        _activeSoundSource.clip = _openSound;
        _activeSoundSource.Play();
    }
    private void OnSomethingWasTransist(TagCanTransit tagCanTransit)
    {
        _activeSoundSource.clip = _stepSound;
        _activeSoundSource.Play();
    }
}
