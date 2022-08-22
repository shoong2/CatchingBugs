using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moki : MonoBehaviour
{
    Transform player;
    public float speed;

    Rigidbody rigid;
    // private Rigidbody bulletRigidbody;
    // void Start()
    // {
    //     bulletRigidbody = GetComponent<Rigidbody>();
    //     bulletRigidbody.velocity = transform.forward*speed;
        
    void Start() {
        player = GameObject.FindWithTag("Player").transform;
        rigid = GetComponent<Rigidbody>();
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

    
}
