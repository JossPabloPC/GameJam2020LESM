using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioMixer : MonoBehaviour
{
    public static AudioMixer instance;

    public AudioSource music_bit;
    public AudioSource sfx_rat;
    public AudioSource sfx_blocker;

    public AudioClip gameplay;
    public AudioClip escapistWin;
    public AudioClip blockerWin;

    public AudioClip door;
    public AudioClip decoy_die;
    public AudioClip lockpick;
    public AudioClip eating;


    private void Awake()
    {
        instance = this;
        music_bit.clip = gameplay;
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
}
