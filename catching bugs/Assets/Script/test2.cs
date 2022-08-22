using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test2 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject item;
    // public GameObject arrow;
    Vector3 targetpos;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        targetpos = new Vector3(item.transform.position.x, transform.position.y, item.transform.position.z);
            transform.LookAt(targetpos);
    }
}
