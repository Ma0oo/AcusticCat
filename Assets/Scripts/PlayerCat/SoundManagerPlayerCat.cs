using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerPlayerCat : MonoBehaviour
{
    [Header("Источники")]
    [SerializeField] private AudioSource[] _source;

    [Header("Звуки")]
    [SerializeField] private AudioClip _step;
    [SerializeField] private AudioClip _meow;

    private void Awake()
    {
        foreach (var source in _source)
        {
            source.playOnAwake = false;
        }
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

    public void StopallSound()
    {
        foreach (var source in _source)
        {
            source.Stop();
        }
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
            default:
                throw new System.Exception("Ты мне че скормил?!?!?");
        }
    }

    public enum TypeSound
    {
        Step, Meow
    }
}
