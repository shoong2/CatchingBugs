using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Audio : MonoBehaviour
{


    public static Audio instance;

    public AudioClip itemSound;
    public AudioClip WaveSound;

    AudioSource myAudio;
    
    [SerializeField] AudioClip[] clip;

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
        myAudio.PlayOneShot(WaveSound);
    }

    public void BugDie_Sound()
    {
        int _temp = Random.Range(0,4);

        myAudio.clip = clip[_temp];
        myAudio.Play();
    }

    public void itemsound()
    {
        myAudio.PlayOneShot(itemSound);
    }

}
