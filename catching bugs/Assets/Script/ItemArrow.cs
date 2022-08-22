using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemArrow : MonoBehaviour
{
    public Transform target;

    void Start()
    {
        // target = GameObject.FindWithTag("Player").transform;
       
        // arrow = GameObject.FindWithTag("arrow");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) {
        if(other.tag =="itemcol")
        {
            gameObject.transform.LookAt(target);
        }
    }
}
