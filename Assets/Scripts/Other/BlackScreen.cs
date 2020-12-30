using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;
using UnityEngine.UI;

public class BlackScreen : MonoBehaviour
{
    public event UnityAction NowBlackScreen;

    [SerializeField] private Image _imageBlackScreen;
    [SerializeField] private float _DurationToBlackScreen;
    [SerializeField] private float _DurationToWhiteScreen;
    
    public void StartToBlackScreen()
    {
        Color color = _imageBlackScreen.color;
        color.a = 1;
        _imageBlackScreen.DOColor(color, _DurationToBlackScreen);
        StartCoroutine(WaitBlackScreen());
    }

    public void StartToWhiteScreen()
    {
        Color color = _imageBlackScreen.color;
        color.a = 0;
        _imageBlackScreen.DOColor(color, _DurationToWhiteScreen);
    }

    private IEnumerator WaitBlackScreen()
    {
        do
        {
            yield return null;
        }
        while((_imageBlackScreen.color.a != 1));
        NowBlackScreen?.Invoke();
    }
}
