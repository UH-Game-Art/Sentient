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

    public AudioClip jump;
    private AudioSource jumpsource;

    public AudioClip death;
    private AudioSource deathsource;

    public AudioClip menu;
    private AudioSource menusource;
    public AudioClip menu_background;
    private AudioSource menu_background_source;

    public AudioClip menu_clicking;
    private AudioSource menu_clicking_source;

    public AudioClip hp;
    private AudioSource hpsource;

    public AudioClip player_bullet;
    private AudioSource player_bullet_source;

    public AudioClip barrel_destroy;
    private AudioSource barrel_destroy_source;

    public AudioClip ready;
    private AudioSource readysource;



    public AudioClip theme;
    private AudioSource themesource;

    public AudioClip theme2;
    private AudioSource themesource2;

    private void Awake()
    {
        instance = this;
    }

    public void PlaySound(AudioClip clip, float volume, bool isLoopback)
    {
        if (clip == this.theme)
        {
            Play(clip, ref themesource, volume, isLoopback);

        }

        if (clip == this.menu_background)
        {
            Play(clip, ref menu_background_source, volume, isLoopback);

        }

        if (clip == this.theme2)
        {
            Play(clip, ref themesource2, volume, isLoopback);

        }

    }


    public void PlaySound(AudioClip clip, float volume)
    {
        if (clip == this.player_bullet)
        {
            Play(clip, ref player_bullet_source, volume);
            return;
        }

        if (clip == this.death)
        {
            Play(clip, ref deathsource, volume);
            return;

        }
        if (clip == this.menu)
        {
            Play(clip, ref menusource, volume);
            return;
        }

        if (clip == this.menu_clicking)
        {
            Play(clip, ref menu_clicking_source, volume);
            return;
        }
        if (clip == this.barrel_destroy)
        {
            Play(clip, ref barrel_destroy_source, volume);
            return;
        }

        if (clip == this.coin)
        {
            Play(clip, ref coinsource, volume);
            return;
        }

        if (clip == this.hp)
        {
            Play(clip, ref hpsource, volume);
            return;
        }

        if (clip == this.jump)
        {
            Play(clip, ref jumpsource, volume);
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
        if (clip == this.coin)
        {
            coinsource?.Stop();  // if not null stop
            return;
        }

        if (clip == this.player_bullet)
        {
            player_bullet_source?.Stop();  // if not null stop
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
