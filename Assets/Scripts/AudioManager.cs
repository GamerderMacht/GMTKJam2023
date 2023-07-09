using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    
    AudioSource audioSource;

    [Header("Sounds for Spawned Objects")]
    public AudioClip[] spawnSounds;
    public AudioClip[] poseHitSounds;
    public AudioClip[] poseFailSounds;

    private void Start() {
        audioSource = GetComponent<AudioSource>();
    }

    void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
    public void PlayPoseHitSound()
    {
        int index = Random.Range(0, poseHitSounds.Length);
        PlaySound(poseHitSounds[index]);
    }
    public void PlayPoseFailSound()
    {
        int index = Random.Range(0, poseFailSounds.Length);
        PlaySound(poseFailSounds[index]);
    }
    public void PlaySpawnSound()
    {
        int index = Random.Range(0, spawnSounds.Length);
        PlaySound(spawnSounds[index]);
    }
}
