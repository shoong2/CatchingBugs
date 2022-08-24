using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moki : MonoBehaviour
{
    Transform player;
    public float speed;
    //AudioSource theAudio;

    Rigidbody rigid;
    // private Rigidbody bulletRigidbody;
    // void Start()
    // {
    //     bulletRigidbody = GetComponent<Rigidbody>();
    //     bulletRigidbody.velocity = transform.forward*speed;
    //[SerializeField] AudioClip[] clip;
        
    void Start() {
        player = GameObject.FindWithTag("Player").transform;
        rigid = GetComponent<Rigidbody>();
        //theAudio = GetComponent<AudioSource>();
    }

    
    
   
    void Update() {
        transform.LookAt(player);
        transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }

    public void die()
    {
        
        Destroy(gameObject);
    }

    void FreezeVelocity()
    {
         rigid.velocity = Vector3.zero;
    //     rigid.angularVelocity = Vector3.zero;
    }
    void FixedUpdate() {
          FreezeVelocity();
    }
    

    private void OnTriggerEnter(Collider other) 
    {
        if(other.tag =="spray")
            {
                Audio.instance.BugDie_Sound();
                Destroy(gameObject);

            }   
    }

    // public void PlaySE()
    // {
    //     int _temp = Random.Range(0,4);

    //     theAudio.clip = clip[_temp];
    //     theAudio.Play();
    // }
}
