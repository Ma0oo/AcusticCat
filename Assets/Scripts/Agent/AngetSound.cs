using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AngetSound : MonoBehaviour
{
    [SerializeField] private AudioClip[] _bormotanya;
    [SerializeField] private AudioClip _finish;

    private AudioSource _source;
    private Coroutine _corutinePlaySound;
    private Agent _agent;

    private void Awake()
    {
        _source = GetComponent<AudioSource>();
        _agent = GetComponent<Agent>();
    }
    private void OnEnable()
    {
        _agent.FinishListen += OnFinishListen;
    }
    private void OnDisable()
    {
        _agent.FinishListen -= OnFinishListen;
    }

    private void OnFinishListen()
    {
        StopCoroutine(_corutinePlaySound);
        _source.clip = _finish;
        _source.Play();
        Destroy(this);
    }
    public void PlaySound()
    {
        if (_corutinePlaySound != null)
            StopCoroutine(_corutinePlaySound);
        _corutinePlaySound = StartCoroutine(PlayRandomSound());
    }
    public void StopSound()
    {
        _source.Stop();
        if (_corutinePlaySound != null)
            StopCoroutine(_corutinePlaySound);
    }
    private IEnumerator PlayRandomSound()
    {
        _source.clip = _bormotanya[Random.Range(0, _bormotanya.Length)];
        _source.Play();
        yield return new WaitForSeconds(_source.clip.length);
        _corutinePlaySound = StartCoroutine(PlayRandomSound());
    }
}
