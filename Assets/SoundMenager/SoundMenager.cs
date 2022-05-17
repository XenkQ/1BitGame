using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMenager : MonoBehaviour
{
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(AudioClip audioClip)
    {
        audioSource.PlayOneShot(audioClip);
    }

    public void StopAllSounds()
    {
        audioSource.Stop();
    }
}
