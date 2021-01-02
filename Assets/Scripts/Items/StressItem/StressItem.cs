using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class StressItem : MonoBehaviour
{
    [SerializeField] private AudioClip _audioClip;
    [Range(0, 100)] [SerializeField] private float _chanceToStress;
    [Range(0,100)][SerializeField] private float _valueStess;
    [SerializeField] private Image _bar;
    [SerializeField] private ParticleSystem _particel;
    [SerializeField] private float _coolDown;

    private float _currentCoolDown;
    private AudioSource _source;

    private void Start()
    {
        _source = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (Random.Range(0, 100) < _chanceToStress && _currentCoolDown == 0)
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
        transform.DOMoveY(pos.y + 0.2f, 0.05f).SetLoops(16, LoopType.Yoyo);
        Instantiate(_particel, _bar.transform.position, Quaternion.identity);
        StartCoroutine(CoolDownStart());
    }

    private IEnumerator CoolDownStart()
    {
        _currentCoolDown = _coolDown;
        while (_currentCoolDown > 0)
        {
            _currentCoolDown -= Time.deltaTime;
            if (_currentCoolDown < 0)
                _currentCoolDown = 0;
            _bar.fillAmount = _currentCoolDown / _coolDown;
            yield return null;
        } 
    }
}
