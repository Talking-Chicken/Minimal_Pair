using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : Singleton<SoundManager>
{
    public AudioSource UIAudioSource, BGMAudioSource;
    [SerializeField] private AudioMixerGroup pitchBendGroup;
    private float audioSpeed = 1.0f;
    [SerializeField] private AudioClip tickTock;

    public float AudioSpeed {get=>audioSpeed; set=>audioSpeed=value;}
    void Start()
    {
        UIAudioSource.outputAudioMixerGroup = pitchBendGroup;
        
    }

    
    void Update()
    {
        UIAudioSource.pitch = AudioSpeed;
        pitchBendGroup.audioMixer.SetFloat("PitchBend", 1f / AudioSpeed);
    }

    public void playUISound(AudioClip audioClip) {
        UIAudioSource.loop = false;
        UIAudioSource.clip = audioClip;
        UIAudioSource.Play();
    }

    public void playBGM(AudioClip audioClip) {
        BGMAudioSource.loop = true;
        BGMAudioSource.clip = audioClip;
        BGMAudioSource.Play();
    }

    public void playTimeSound() {
        playBGM(tickTock);
    }
}
