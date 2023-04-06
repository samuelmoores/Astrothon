using UnityEngine.Audio;
using UnityEngine;

//All scripts wrote and developed in conjuction with youtube.com @Brackeys, @JasonWeiman and @CodeMonkey

[System.Serializable]
public class Sound 
{
    public string name;

    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume;
    [Range(.1f, 3f)]
    public float pitch;

    public bool loop;

    [HideInInspector]
    public AudioSource source;
}
