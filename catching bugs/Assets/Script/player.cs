using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public bool isDie;
    AudioSource itemSnd;

    void Start()
    {
        isDie = false;
        itemSnd = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision other) {

         if(other.gameObject.tag == "moki")
        {
            
            isDie = true;
        }

        else if(other.gameObject.tag == "baki")
        {
            isDie = true;
        }

        

       
    }
    // void OnTriggerEnter(Collider other) {
    //     if(other.tag == "moki")
    //     {
    //         isDie = true;
    //     }
    // }

    public void itemAudio()
    {
        itemSnd.Play();
    }

}
