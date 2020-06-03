using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.TerrainAPI;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    void Awake()
    {
        foreach (var s in sounds)
        {
            gameObject.AddComponent<AudioSource>();
            s.audioSource.clip = s.audioClip;
            s.audioSource.pitch = s.pitch;
            s.audioSource.volume = s.volume;
        }
    }
    private void Start()
    {
        Play("atBegging");
    }
    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        
        s.audioSource.clip = s.audioClip;
        s.audioSource.Play();
    }
}
