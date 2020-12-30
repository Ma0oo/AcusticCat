using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Arrow : MonoBehaviour
{
    [SerializeField] private float _diferentScale;
    [SerializeField] private float _durrationOneLoop;
    [SerializeField] private float _distaceMin;
    [SerializeField] private float _distaceMax;

    private Camera _camera;
    private SpriteRenderer _sprite;

    void Start()
    {
        transform.DOScale(transform.localScale.x + _diferentScale, _durrationOneLoop).SetLoops(-1, LoopType.Yoyo);
        _camera = Camera.main;
        _sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Color color = _sprite.color;
        float distaceToCamera = Vector3.Distance(transform.position, _camera.transform.position);
        if (distaceToCamera < _distaceMin)
            color.a = 0;
        else if (distaceToCamera > _distaceMax)
            color.a = 1;
        else
            color.a = distaceToCamera / _distaceMax;


        _sprite.color = color;
    }

}