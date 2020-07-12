using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundController : MonoBehaviour
{
    public static SoundController instance;

    public AudioMixer musicVar;
    public AudioMixer sfxVar;

    public AudioSource music_bit;
    public AudioSource sfx_rat;
    public AudioSource sfx_blocker;

    public AudioClip sceneMusic;
    public AudioClip escapistWin;
    public AudioClip blockerWin;
    public AudioClip pause;

    public AudioClip door;
    public AudioClip decoy_die;
    public AudioClip lockpick;
    public AudioClip eating;
    public AudioClip exit;
    public AudioClip poisonCheese;


    private void Awake()
    {
        instance = this;
        music_bit.clip = sceneMusic;
        music_bit.Play();
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setMusicVol(float clip)
    {
        musicVar.SetFloat("musicVol", clip);
    }

    public void setSfxVol(float clip)
    {
        sfxVar.SetFloat("sfxVol", clip);
    }
    
}
