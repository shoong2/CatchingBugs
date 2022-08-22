using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Audio : MonoBehaviour
{


    public static Audio instance;

    public AudioClip mokiDie;
    public AudioClip sndWave;

    AudioSource myAudio;
    

    void Start()
    {
        myAudio = GetComponent<AudioSource>();

        if(instance ==null)
        {
            instance = this;
        }
    }

    public void newWave()
    {
        myAudio.PlayOneShot(sndWave);
    }

}
