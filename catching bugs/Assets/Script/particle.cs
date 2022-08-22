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

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) {
        
        if(other.tag == "moki")
        {
            PlaySE();
            Moki moki = other.GetComponent<Moki>();
            if(moki != null)
            {
                //GameManager.instance.mokiCount +=1;
                GameManager.instance.data.coin+=1;
                moki.die();
            }
        }

        // else if(other.tag == "baki")
        // {
        //     bakiDie +=1;
        //     newMoki baki = other.GetComponent<newMoki>();
        //     Rigidbody rigid = other.GetComponent<Rigidbody>();
        //     if(baki != null)
        //     {
        //         Vector3 reactVec = baki.transform.position - transform.position;
        //         // moki.die();
                
        //         reactVec = reactVec.normalized;
        //         // reactVec += Vector3.up;

        //         rigid.AddForce(reactVec *50, ForceMode.Impulse);

                
                
        //     }

        //     if(bakiDie == 3)
        //     {
        //         baki.die();
        //     }
        //}
        
    }

   

     public void PlaySE()
    {
        int _temp = Random.Range(0,4);

        theAudio.clip = clip[_temp];
        theAudio.Play();
    }
}
