using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingVolume : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _mixer;


    public void ChangeMusic(float volume)
    {
        _mixer.audioMixer.SetFloat("Music", volume);
    }

    public void ChangeEffect(float volume)
    {
        _mixer.audioMixer.SetFloat("Effect", volume);
    }

    public void ChangeBipBop(float volume)
    {
        _mixer.audioMixer.SetFloat("BipBop", volume);
    }
}


