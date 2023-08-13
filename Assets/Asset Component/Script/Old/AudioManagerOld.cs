using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerOld : MonoBehaviour
{
    public static AudioManagerOld singleton;
    public AudioClip[] clip;
    AudioSource audioSource;

    private void Awake()
    {
        singleton = this;
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(int clipIndex)
    {
        audioSource.PlayOneShot(clip[clipIndex]);
    }
}
