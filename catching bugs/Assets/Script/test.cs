using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class test : MonoBehaviour
{
    // public GameObject item;
    // public GameObject arrow;
    Vector3 targetpos;
    // public GameObject arrow;
    // Transform arrowPos;
    // Start is called before the first frame update
    void Start()
    {
        // arrowPos = arrow.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        // arrowPos.Rotate(new Vector3(0,0,transform.rotation.y));
        
        // arrowPos.transform.rotation = Quaternion.Euler(0, transform.rotation.y *Time.deltaTime, 0);
    }

    

     void OnTriggerStay(Collider other) {

          if(other.tag =="itemcol")
        {
            
            targetpos = new Vector3(other.transform.position.x, transform.position.y, other.transform.position.z);
            transform.LookAt(targetpos);
            
            
        }
     }
       
    
}
