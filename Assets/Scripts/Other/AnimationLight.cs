using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AnimationLight : MonoBehaviour
{
    private Light _light;
    [SerializeField] private float _minusIntensive;
    [SerializeField] private float _plusIntensive;
    [SerializeField] private float _minDuration;
    [SerializeField] private float _maxDuration;

    private float _duration;
    private float _maxIntensive;
    private float _minIntensive;

    private void Awake()
    {
        _light = GetComponentInChildren<Light>();
        _maxIntensive = Random.Range(_light.intensity, _light.intensity + _plusIntensive);
        _minIntensive = Random.Range(_light.intensity, _light.intensity - _minusIntensive);
        _light.intensity = _minIntensive;
        _duration = Random.Range(_minIntensive, _maxIntensive);
        _light.DOIntensity(_maxIntensive, _duration).SetLoops(-1, LoopType.Yoyo);
    }

}
