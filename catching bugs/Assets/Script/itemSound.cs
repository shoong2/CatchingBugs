using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemSound : MonoBehaviour
{
    AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other) {
        if(other.tag =="item")
        {
            Debug.Log("ggggg");
          
        }
    }
    void Update()
    {
        
    }
}
