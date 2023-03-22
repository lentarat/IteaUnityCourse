using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;


[System.Serializable]
public class Sound
{
    public string _name;
    //public string Name => _name;

    //public AudioSource _audioSource;
    public AudioClip _clip;
    public AudioMixerGroup _audioMixer;
    //public AudioSource AudioSource => _audioSource;

}