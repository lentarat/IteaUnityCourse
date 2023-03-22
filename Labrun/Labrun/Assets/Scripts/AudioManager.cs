using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private Sound[] _sounds;
    [SerializeField] private AudioSource _audioSource;
    //private bool wasStopped;
    public void Play(string name)
    {
        if (_audioSource.clip.name == name)
        { 
            _audioSource.UnPause();
            return;
        }
        foreach (Sound go in _sounds)
        {
            if (go._name == name)
            {
                _audioSource.Stop();
                _audioSource.clip = go._clip;
                _audioSource.outputAudioMixerGroup = go._audioMixer;
                _audioSource.Play();
                break;
            }
        }
    }
    public void Pause()
    {
        _audioSource.Pause();
    }
}

