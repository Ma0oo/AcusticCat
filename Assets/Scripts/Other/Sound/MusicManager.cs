using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private AudioClip[] _musics;

    private AudioSource _audio;

    private void Start()
    {
        _audio = GetComponent<AudioSource>();
        PlayRandomMusic();
        StartCoroutine(SetNewTrack());
    }

    private void PlayRandomMusic()
    {
        if (_musics.Length > 0)
        {
            _audio.clip = _musics[Random.Range(0, _musics.Length)];
            _audio.Play();
        }
    }
    private void OnFinishPlayMusic()
    {
        PlayRandomMusic();
        StartCoroutine(SetNewTrack());
    }

    private IEnumerator SetNewTrack()
    {
        yield return new WaitForSeconds(_audio.clip.length);
        OnFinishPlayMusic();
    }
}
