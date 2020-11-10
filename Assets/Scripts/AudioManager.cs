using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Permissions;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static AudioManager instance;
    public GameObject prefab;
    public AudioClip coin;
    private AudioSource coinsource;

    public AudioClip shoot;
    private AudioSource shootsource;

    public AudioClip kill;
    private AudioSource killsource;

    public AudioClip click;
    private AudioSource clicksource;

    public AudioClip barrel;
    private AudioSource barrelsource;

    public AudioClip jump;
    private AudioSource jumpsource;

    public AudioClip theme;
    private AudioSource themesource;

    public AudioClip theme2;
    private AudioSource themesource2;

    private void Awake()
    {
        instance = this;
    }
    
    public void PlaySound(AudioClip clip, float volume, bool isLoopback )
    {
        if (clip == this.theme)
        {
            Play(clip, ref themesource, volume, isLoopback);
        }

        if (clip == this.theme2)
        {
            Play(clip, ref themesource2, volume, isLoopback);
        }

    }


    public void PlaySound(AudioClip clip, float volume)
    {
        if (clip == this.coin)
        {
            Play(clip, ref coinsource, volume);
            return;
        }

        if (clip == this.barrel)
        {
            Play(clip, ref barrelsource, volume);
            return;
        }

        if (clip == this.click)
        {
            Play(clip, ref clicksource, volume);
            return;
        }

        if (clip == this.jump)
        {
            Play(clip, ref jumpsource, volume);
            return;
        }

        if (clip == this.kill)
        {
            Play(clip, ref killsource, volume);
            return;
        }

        if (clip == this.shoot)
        {
            Play(clip, ref shootsource, volume);
            return;
        }
    }


    private void Play(AudioClip clip, ref AudioSource audioSource, float volume, bool isLoopback=false)
    {
        if(audioSource != null && audioSource.isPlaying)  // if sound is playing
        {
            return;  // do nothing
        }
        audioSource = Instantiate(instance.prefab).GetComponent<AudioSource>();

        audioSource.volume = volume;
        audioSource.loop = isLoopback;
        audioSource.clip = clip;
        audioSource.Play();
        Destroy(audioSource.gameObject, audioSource.clip.length);  // end music
    }


    public void StopSound(AudioClip clip)
    {
        if (clip == this.jump)
        {
            jumpsource?.Stop();  // if not null stop
            return;
        }

        if (clip == this.barrel)
        {
            barrelsource?.Stop();  // if not null stop
            return;
        }

        if (clip == this.shoot)
        {
            shootsource?.Stop();  // if not null stop
            return;
        }

        if (clip == this.kill)
        {
            killsource?.Stop();  // if not null stop
            return;
        }

        if (clip == this.coin)
        {
            coinsource?.Stop();  // if not null stop
            return;
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
