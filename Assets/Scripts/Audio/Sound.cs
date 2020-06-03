using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
[Serializable]
public class Sound 
{
    public string name;
    public AudioClip audioClip;
    public float volume;
    public float pitch;

    public AudioSource audioSource;
}
