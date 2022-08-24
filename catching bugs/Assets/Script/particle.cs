using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particle : MonoBehaviour
{
    AudioSource theAudio;
    // int bakiDie;

    [SerializeField] AudioClip[] clip;
    // Start is called before the first frame update
    void Start()
    {
         theAudio = GetComponent<AudioSource>();
        //  bakiDie = 0;
    }

 

    // void OnTriggerEnter(Collider other) 
    // {
        
    //     if(other.tag == "moki")
    //     {
    //         PlaySE();
    //         Moki moki = other.GetComponent<Moki>();
    //         if(moki != null)
    //         {
    //             //GameManager.instance.mokiCount +=1;
    //             GameManager.instance.data.coin+=1;
    //             moki.die();
    //         }
    //     }   
        
    // }

   

    public void PlaySE()
    {
        int _temp = Random.Range(0,4);

        theAudio.clip = clip[_temp];
        theAudio.Play();
    }
}
