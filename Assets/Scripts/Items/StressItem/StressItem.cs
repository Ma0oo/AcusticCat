using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(AudioSource))]
public class StressItem : MonoBehaviour
{
    [SerializeField] private AudioClip _audioClip;
    [Range(0, 100)] [SerializeField] private float _chanceToStress;
    [Range(0,100)][SerializeField] private float _valueStess;

    private AudioSource _source;

    private void Start()
    {
        _source = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (Random.Range(0, 100) < _chanceToStress)
        {
            if(other.TryGetComponent(out PlayerCatAI playerCat))
            {
                playerCat.Stressed(_valueStess);
                TurnOn();
            }
        }
    }

    private void TurnOn()
    {
        _source.clip = _audioClip;
        _source.Play();
        Vector3 pos = transform.position;
        transform.DOMoveY(pos.y + 0.2f, 0.05f).SetLoops(10, LoopType.Yoyo);
    }
}
