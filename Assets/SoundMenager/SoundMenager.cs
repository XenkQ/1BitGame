using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMenager : MonoBehaviour
{
    [SerializeField] [Range(0,1f)] private float soundVolume = 0.90f;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(AudioClip audioClip)
    {
        audioSource.PlayOneShot(audioClip, soundVolume);
    }

    public void StopAllSounds()
    {
        audioSource.Stop();
    }
}
